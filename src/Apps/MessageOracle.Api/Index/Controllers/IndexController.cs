using Microsoft.AspNetCore.Mvc;

namespace MessageOracle.Api.Answering.Controllers;

[ApiController]
[Route("/")]
public class IndexController : ControllerBase
{

    [HttpGet]
    public ActionResult<string> Index()
        => Ok("You have reached the MessageOracle Api.\r\n\r\nWelcome! :)");
}
