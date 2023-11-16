using System.Numerics;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.Health.Fhir.CodeGenCommon.Models;
using Microsoft.Health.Fhir.SourceGenerator.Parsing;
using Microsoft.Health.Fhir.SpecManager.Converters;
using Microsoft.Health.Fhir.SpecManager.Language;
using Microsoft.Health.Fhir.SpecManager.Manager;
using Microsoft.Health.Fhir.SpecManager.Models;

namespace Microsoft.Health.Fhir.SourceGenerator;

internal class Emitter
{
    private delegate bool TryGetModel<TModel>(FhirVersionInfo versionInfo, string key, out TModel? model) where TModel : class;
    private readonly ILanguage _language;
    private readonly IFhirConverter _fhirConverter = new FromFhirExpando();
    private readonly FhirVersionInfo _fhirInfo = new FhirVersionInfo(FhirPackageCommon.FhirSequenceEnum.R4B);
    private readonly Action<Diagnostic> _report;

    public Emitter(
        FhirVersionInfo fhirInfo,
        ILanguage language,
        Action<Diagnostic> report)
    {
        _report = report;
        _fhirInfo = fhirInfo;
        _language = language;
    }

    public string? EmitSharedValueSets(string sharedNs, string[] sharedValueSets)
    {
        ProcessTerminologyArtifacts(sharedValueSets, _fhirInfo, (FhirVersionInfo m, string k, out object? v) => TryGetFhirTerminology(m, k, out v));

        foreach (var item in _fhirInfo.ValueSetsByUrl)
        {
            var vs = item.Value;
            foreach (var v in vs.ValueSetsByVersion)
            {
                v.Value.Resolve(_fhirInfo.CodeSystems);
            }
        }

        _language.Namespace = sharedNs;
        using var memoryStream = new MemoryStream();
        _language.ExportSharedValueSets(_fhirInfo, memoryStream);
        memoryStream.Position = 0;

        if (memoryStream.Length == 0)
        {
            _report(Diagnostic.Create(DiagnosticDescriptors.FailedToGenerate, Location.None, "Shared"));
            return null;
        }

        var code = Encoding.UTF8.GetString(memoryStream.ToArray());
        return code;
    }

    public string? Emit(ResourcePartialClass resource)
    {
        try
        {
            ProcessTerminologyArtifacts(resource.TerminologyResourcePaths, _fhirInfo, (FhirVersionInfo m, string k, out object? v) => TryGetFhirTerminology(m, k, out v));

            foreach (var item in _fhirInfo.ValueSetsByUrl)
            {
                var vs = item.Value;
                foreach (var v in vs.ValueSetsByVersion)
                {
                    v.Value.Resolve(_fhirInfo.CodeSystems);
                }
            }

            return ProcessStructureDefinition(resource, _fhirInfo);

        }
        catch (ReflectionTypeLoadException rex)
        {
            _report(Diagnostic.Create(DiagnosticDescriptors.TypeLoaderException, Location.None, rex.LoaderExceptions));
        }
        catch (Exception ex)
        {
            _report(Diagnostic.Create(DiagnosticDescriptors.UnhandledException, Location.None, ex));
        }

        return null;
    }

    private static bool TryGetFhirTerminology(FhirVersionInfo m, string key, out object? value)
    {
        FhirValueSet? valueset = null;
        FhirCodeSystem? codeSystem = null;
        if (m.CodeSystems.TryGetValue(key, out codeSystem) ||
            m.TryGetValueSet(key, out valueset))
        {
            value = (object)codeSystem ?? (object)valueset!;
            return true;
        }
        else
        {
            value = null;
            return false;
        }
    }

    private void ProcessTerminologyArtifacts<TModel>(
        string[] resourcePaths,
        FhirVersionInfo fhirInfo,
        TryGetModel<TModel> modelCollectionLocator)
        where TModel : class
    {
        foreach (var path in resourcePaths)
        {
            if (path is null)
            {
                continue;
            }

            var model = ProcessFile(path, fhirInfo, _fhirConverter, modelCollectionLocator, out var fileName, out var canonical, out var artifactClass);
            if (model == null || (artifactClass != FhirArtifactClassEnum.CodeSystem && artifactClass != FhirArtifactClassEnum.ValueSet))
            {
                _report(Diagnostic.Create(DiagnosticDescriptors.FailedArtifactDef, Location.None, path, "CodeSystem or ValueSet"));
                continue;
            }

            _report(Diagnostic.Create(DiagnosticDescriptors.ProcessSuccess, Location.None, path, canonical, artifactClass, fhirInfo.Resources.Count));
        }
    }


    private string? ProcessStructureDefinition(ResourcePartialClass resource, FhirVersionInfo fhirInfo)
    {
        var structureDef = resource.StructureDefinitionPath;
        var complex = ProcessFile(structureDef, fhirInfo, _fhirConverter, m => m.Resources, out var id, out var canonical, out var artifactClass);
        if (complex == null || artifactClass != FhirArtifactClassEnum.Resource)
        {
            _report(Diagnostic.Create(DiagnosticDescriptors.FailedArtifactDef, Location.None, structureDef, FhirArtifactClassEnum.Resource));
            return null;
        }
        else if (complex.Name != resource.Name)
        {
            _report(Diagnostic.Create(DiagnosticDescriptors.ResourceNameMismatch, resource.Location, complex.Name, resource.Name));
            return null;
        }

        _report(Diagnostic.Create(DiagnosticDescriptors.ProcessSuccess, Location.None, structureDef, canonical, artifactClass, fhirInfo.Resources.Count));

        return GenerateFhirResourceSource(resource.Namespace, fhirInfo, complex, structureDef);


    }

    private string? GenerateFhirResourceSource(string ns, FhirVersionInfo fhirInfo, FhirComplex complex, string originalFilePath)
    {
        _language.Namespace = ns;
        using var memoryStream = new MemoryStream();
        _language.Export(fhirInfo, complex, memoryStream);
        memoryStream.Position = 0;

        if (memoryStream.Length == 0)
        {
            _report(Diagnostic.Create(DiagnosticDescriptors.FailedToGenerate, Location.None, originalFilePath));
            return null;
        }

        var code = Encoding.UTF8.GetString(memoryStream.ToArray());
        return code;
    }

    internal static TModel? ProcessFile<TModel>(
        string path,
        FhirVersionInfo fhirInfo,
        IFhirConverter fhirConverter,
        Func<FhirVersionInfo, Dictionary<string, TModel>> modelCollectionAccessor,
        out string fileName,
        out string? canonical,
        out FhirArtifactClassEnum artifactClass)
        where TModel : class
        => ProcessFile(path, fhirInfo, fhirConverter, (FhirVersionInfo m, string k, out TModel? v) => modelCollectionAccessor(m).TryGetValue(k, out v), out fileName, out canonical, out artifactClass);

    private static TModel? ProcessFile<TModel>(
        string path,
        FhirVersionInfo fhirInfo,
        IFhirConverter fhirConverter,
        TryGetModel<TModel> modelCollectionLocator,
        out string id,
        out string? canonical,
        out FhirArtifactClassEnum artifactClass)
        where TModel : class
    {
        id = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(path));

        if (!File.Exists(path))
        {
            canonical = null;
            artifactClass = default;
            return null;
        }

        var json = File.ReadAllText(path);

        if (!fhirConverter.TryParseResource(json, out var resource, out _))
        {
            canonical = null;
            artifactClass = default;
            return null;
        }

        if (resource is FhirExpando expando)
        {
            if (expando.TryGetValue("type", out var typeVal) && typeVal is string typeName)
            {
                id = typeName;
            }
            else if (expando.TryGetValue("url", out var urlVal) && urlVal is string url)
            {
                id = url;
            }
            else if (expando.TryGetValue("id", out var idVal) && urlVal is string id2)
            {
                id = id2;
            }
        }

        fhirInfo.ProcessResource(resource, out canonical, out artifactClass);

        modelCollectionLocator(fhirInfo, id, out var model);
        return model;
    }
}
