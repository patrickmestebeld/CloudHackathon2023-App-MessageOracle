using MessageOracle.Api.Personal.Models;
using MessageOracle.Core.Personal.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MessageOracle.Api.Answering.Controllers;

[ApiController]
[Route("personal")]
public class PersonalController : ControllerBase
{
    private readonly ILogger<PersonalController> _logger;
    private readonly IPersonalDataGenerator _personalDataGenerator;

    public PersonalController(ILogger<PersonalController> logger, IPersonalDataGenerator personalDataGenerator)
    {
        _logger = logger;
        _personalDataGenerator = personalDataGenerator;
    }

    [HttpGet]
    public ActionResult<PersonalDataDto> Get(Guid key) => Ok(PersonalDataDto.FromPersonalData(_personalDataGenerator.Generate(key)));
}
