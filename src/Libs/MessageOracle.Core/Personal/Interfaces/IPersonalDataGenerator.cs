using MessageOracle.Core.Personal.Entities;

namespace MessageOracle.Core.Personal.Interfaces;

public interface IPersonalDataGenerator
{
    PersonalData Generate(Guid key);
}
