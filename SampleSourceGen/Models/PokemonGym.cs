using Microsoft.Health.Fhir.CodeGeneration;

namespace SampleSourceGen.Models;

[GeneratedFhir(
    "Models/PokemonGym.StructureDefinition.json",
    TerminologyResources = new[] { "Models/PokemonRegion.CodeSystem.json", "Models/PokemonRegion.ValueSet.json" },
    SharedTerminologyResources = new[] { "Models/PokemonType.CodeSystem.json", "Models/PokemonType.ValueSet.json" })]
public partial class PokemonGym
{
}
