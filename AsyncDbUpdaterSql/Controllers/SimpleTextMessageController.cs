using Microsoft.AspNetCore.Mvc;

namespace AsyncDbUpdaterSql;


[ApiController]
[Route("[controller]")]
public class SimpleTextMessageController : ControllerBase
{
    
    [HttpGet]
    public IActionResult Get()
    {
        Console.WriteLine("Funcionando Normal o Projeto Consumer");
        return Ok(":)");
    }
}