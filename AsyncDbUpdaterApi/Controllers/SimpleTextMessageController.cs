using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace AsyncDbUpdaterApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SimpleTextMessageController : ControllerBase
{
    private readonly ITopicProducer<string, SimpleTextMessage> _producer;
    public SimpleTextMessageController(ITopicProducer<string, SimpleTextMessage> producer)
    {
        _producer = producer;
    }


    [HttpGet]
    public async Task<IActionResult>Get()
    {
        try{
        var messageId = Guid.NewGuid();
        await _producer.Produce(messageId.ToString(), new SimpleTextMessage{
            Id = messageId,
            MessageText = "TestMessage"
        }, HttpContext.RequestAborted);


        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException.Message);

        }

        return Accepted();
    }
}