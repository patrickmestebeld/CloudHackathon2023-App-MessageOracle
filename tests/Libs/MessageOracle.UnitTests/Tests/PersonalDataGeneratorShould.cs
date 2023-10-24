using MessageOracle.Core.Personal.Interfaces;
using MessageOracle.Infra.Personal.Services;
using Shouldly;

namespace MessageOracle.UnitTests.Tests;

[TestClass]
public class PersonalDataGeneratorShould
{
    private readonly IPersonalDataGenerator _sut = new BogusPersonalDataGenerator();

    [TestMethod]
    public void GeneratePersonalDataCorrectly()
    {
        var actualPersonalData = _sut.Generate(new Guid("895BAF67-15F8-419C-880E-8110A15CB2EF"));

        actualPersonalData.Bsn.Value.ShouldBe("155266019");
        actualPersonalData.Adres.Straatnaam.ShouldBe("Lindensloot");
        actualPersonalData.Adres.Postcode.Value.ShouldBe("6701QG");
        actualPersonalData.Adres.Huisnummer.ShouldBe(263);
        actualPersonalData.Adres.Woonplaats.ShouldBe("Gerslootwoude");
        actualPersonalData.Naam.Voornaam.ShouldBe("Maud");
        actualPersonalData.Naam.Achternaam.ShouldBe("Smit");
        actualPersonalData.Naam.Voorletters.ShouldBe("M.");
    }
}