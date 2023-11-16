using System.Collections.Generic;
using Hl7.Fhir.Model;

var edu = new SampleSourceGen.Education
{
    Study = "abcd",
    Graduated = new FhirBoolean(false),
    Subject = new ResourceReference("/Study/abcd")
};

var patient = new SampleSourceGen.Models.Patient
{
    Contact = new List<SampleSourceGen.Models.Patient.ContactComponent> { },
};

var pkmn = new SampleSourceGen.Models.Pokemon
{
    Name = "Charmander",
    NationalDexNo = 4,
    PrimaryType = SampleSourceGen.Models.PokemonTypes.Fire,
};

var pkmngym = new SampleSourceGen.Models.PokemonGym
{
    Name = "Viridian City Gym",
    Region = SampleSourceGen.Models.PokemonGym.PokemonRegion.Kanto,
    PokemonType = SampleSourceGen.Models.PokemonTypes.Ground,
};

