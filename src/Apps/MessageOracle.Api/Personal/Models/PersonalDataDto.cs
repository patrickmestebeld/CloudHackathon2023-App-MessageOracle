using MessageOracle.Core.Personal.Entities;

namespace MessageOracle.Api.Personal.Models;

public class PersonalDataDto
{
    public Guid Key { get; set; } = Guid.Empty;
    public string Bsn { get; set; } = string.Empty;
    public AdresDto Adres { get; set; } = new();
    public NaamDto Naam { get; set; } = new();

    public static PersonalDataDto FromPersonalData(PersonalData personalData) => new()
    {
        Key = personalData.Key,
        Bsn = personalData.Bsn,
        Adres = new AdresDto
        {
            Straatnaam = personalData.Adres.Straatnaam,
            Huisnummer = personalData.Adres.Huisnummer,
            Postcode = personalData.Adres.Postcode,
            Woonplaats = personalData.Adres.Woonplaats
        },
        Naam = new NaamDto
        {
            Voorletters = personalData.Naam.Voorletters,
            Achternaam = personalData.Naam.Achternaam,
            Voornaam = personalData.Naam.Voornaam
        }
    };
}
