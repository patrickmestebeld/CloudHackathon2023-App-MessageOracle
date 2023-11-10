using Bogus;
using MessageOracle.Core.Personal.ValueObjects;
using MessageOracle.Infra.Personal.Interfaces;

namespace MessageOracle.Infra.Personal.Fakers
{
    internal class BogusNaamGenerator : IObjectGenerator<Naam>
    {
        public Naam Generate(Guid key)
        {
            return new Faker<NaamBuilder>(GeneratorConstants.FakeLocal)
                        .StrictMode(true)
                        .UseSeed(key.GetHashCode())
                        .RuleFor(o => o.Voorletters, _ => ".")
                        .RuleFor(o => o.Achternaam, f => f.Name.LastName())
                        .RuleFor(o => o.Voornaam, f => f.Name.FirstName())
                        .FinishWith((f, o) =>
                        {
                            o.Voorletters = $"{o.Voornaam.Substring(0, 1)}.";
                        })
                        .Generate()
                        .Build();
        }

        internal class NaamBuilder
        {
            public string Voorletters { get; set; } = "";
            public string Achternaam { get; set; } = "";
            public string Voornaam { get; set; } = "";

            public Naam Build() => new(Voorletters, Achternaam, Voornaam);
        }
    }
}
