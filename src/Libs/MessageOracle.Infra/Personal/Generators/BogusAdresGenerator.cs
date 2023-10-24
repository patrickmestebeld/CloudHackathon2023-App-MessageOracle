using Bogus;
using MessageOracle.Core.Personal.ValueObjects;
using MessageOracle.Infra.Personal.Interfaces;

namespace MessageOracle.Infra.Personal.Fakers
{

    internal class BogusAdresGenerator : IObjectGenerator<Adres>
    {
        public Adres Generate(Guid key)
            => new Faker<AdresBuilder>(GeneratorConstants.FAKE_LOCALE)
                .StrictMode(true)
                .UseSeed(key.GetHashCode())
                .RuleFor(o => o.Straatnaam, f => f.Address.StreetName())
                .RuleFor(o => o.Huisnummer, f => f.Random.Number(1, 999))
                .RuleFor(o => o.Postcode, f => f.Random.Replace("####??"))
                .RuleFor(o => o.Woonplaats, f => f.Address.City())
                .Generate()
                .Build();

        internal class AdresBuilder
        {
            public string Straatnaam { get; set; } = "Straatnaam";
            public int Huisnummer { get; set; } = 0;
            public string Postcode { get; set; } = "0000AA";
            public string Woonplaats { get; set; } = "Woonplaats";

            public Adres Build() => new(Postcode, Huisnummer, Woonplaats, Straatnaam);
        }
    }
}
