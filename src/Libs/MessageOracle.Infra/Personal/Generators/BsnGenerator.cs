using MessageOracle.Core.Personal.ValueObjects;
using MessageOracle.Infra.Personal.Interfaces;

namespace MessageOracle.Infra.Personal.Fakers
{
    internal class BsnGenerator : IObjectGenerator<Bsn>
    {
        public Bsn Generate(Guid key)
        {
            if (GeneratorConstants.IsRealistic == false) return new Bsn("123443210");

            int rest; string bsn;
            Random random = new Random(key.GetHashCode());
            do
            {
                bsn = ""; int total = 0; for (int i = 0; i < 8; i++)
                {
                    int rndDigit = random.Next(0, i == 0 ? 2 : 9);
                    total += rndDigit * (9 - i);
                    bsn += rndDigit;
                }
                rest = total % 11;
            }
            while (rest > 9);
            return bsn + rest;
        }
    }
}
