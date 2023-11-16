using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.Health.Fhir.SourceGenerator.Parsing;
using Microsoft.Health.Fhir.SpecManager.Language;
using Microsoft.Health.Fhir.SpecManager.Manager;

namespace Microsoft.Health.Fhir.SourceGenerator
{
    [Generator]
    public class FhirSourceGenerator : ISourceGenerator
    {
        /// <inheritdoc/>
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(SyntaxContextReceiver.Create);
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxContextReceiver is not SyntaxContextReceiver receiver || receiver.ClassDeclarations.Count == 0)
            {
                // nothing to do yet
                return;
            }

#if DEBUG
            System.Diagnostics.Debugger.Launch();
#endif

            var parser = new Parser(context, context.ReportDiagnostic, context.CancellationToken);
            var resourcePartialClasses = parser.GetResourcePartialClasses(receiver.ClassDeclarations);

            var fhirInfo = new FhirVersionInfo(FhirPackageCommon.FhirSequenceEnum.R4B);
            var language = new CSharpFirely2();

            var emitter = new Emitter(fhirInfo, language, context.ReportDiagnostic);
            var resourcesWithShared = resourcePartialClasses.Where(x => x.SharedTerminologyResourcePaths.Length > 0);
            var sharedTerminologyResources = resourcesWithShared.SelectMany(x => x.SharedTerminologyResourcePaths).Distinct().ToArray();

            if (sharedTerminologyResources.Length > 0)
            {
                var sharedNs = resourcesWithShared.Select(x => x.Namespace).OrderBy(x => x.Length).First();
                var sharedCode = emitter.EmitSharedValueSets(sharedNs, sharedTerminologyResources);
                if (!string.IsNullOrEmpty(sharedCode))
                {
                    context.AddSource("SharedValueSets.cs", SourceText.From(sharedCode!, Encoding.UTF8));
                }
            }

            foreach (var resourceClass in resourcePartialClasses)
            {
                var code = emitter.Emit(resourceClass);
                if (!string.IsNullOrEmpty(code))
                {
                    context.AddSource($"{resourceClass.Name}.cs", SourceText.From(code!, Encoding.UTF8));
                }
            }
        }
    }
}
