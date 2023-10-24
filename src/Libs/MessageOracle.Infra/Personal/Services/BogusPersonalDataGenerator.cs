using MessageOracle.Core.Personal.Entities;
using MessageOracle.Core.Personal.Interfaces;
using MessageOracle.Core.Personal.ValueObjects;
using MessageOracle.Infra.Personal.Fakers;
using MessageOracle.Infra.Personal.Interfaces;

namespace MessageOracle.Infra.Personal.Services
{
    internal class BogusPersonalDataGenerator : IPersonalDataGenerator
    {
        private readonly IObjectGenerator<Adres> _adresGenerator = new BogusAdresGenerator();
        private readonly IObjectGenerator<Naam> _naamGenerator = new BogusNaamGenerator();
        private readonly IObjectGenerator<Bsn> _bsnGenerator = new BsnGenerator();

        public PersonalData Generate(Guid key)
            => new(key, _bsnGenerator.Generate(key), _naamGenerator.Generate(key), _adresGenerator.Generate(key));
    }
}
