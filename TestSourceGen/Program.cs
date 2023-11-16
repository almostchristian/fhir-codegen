// See https://aka.ms/new-console-template for more information

using Microsoft.CodeAnalysis;
using Microsoft.Health.Fhir.SourceGenerator;
using Microsoft.Health.Fhir.SourceGenerator.Parsing;
using Microsoft.Health.Fhir.SpecManager.Language;
using Microsoft.Health.Fhir.SpecManager.Manager;

var fhirInfo = new FhirVersionInfo(FhirPackageCommon.FhirSequenceEnum.R4B);
var language = new CSharpFirely2();
var resourceClass = new ResourcePartialClass(Location.None, typeof(Program).Namespace!, "Patient", "Patient.StructureDefinition.json", Array.Empty<string>(), Array.Empty<string>());

var emitter = new Emitter(fhirInfo, language, diag => Console.Error.WriteLine(diag.GetMessage()));

var code = emitter.Emit(resourceClass);

Console.WriteLine(code);
