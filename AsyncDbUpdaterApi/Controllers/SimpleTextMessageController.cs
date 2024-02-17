using Confluent.Kafka;
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
        
        
        var messageId = Guid.NewGuid();
        await _producer.Produce(messageId.ToString(), new SimpleTextMessage{
            Id = messageId,
            MessageText = "TestMessage"
        }, HttpContext.RequestAborted);
        
        return Accepted(":)");
    }
}