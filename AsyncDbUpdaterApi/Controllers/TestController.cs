using Microsoft.AspNetCore.Mvc;

namespace AsyncDbUpdaterApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{

    [HttpGet]
    public string Get()
    {
        return "Hello World! :)";
    }
}