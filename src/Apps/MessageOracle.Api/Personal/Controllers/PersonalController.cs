using MessageOracle.Core.Personal.Entities;
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
    public ActionResult<PersonalData> Get(Guid key) => Ok(_personalDataGenerator.Generate(key));
}
