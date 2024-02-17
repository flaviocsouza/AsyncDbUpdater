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
        

        // Console.WriteLine(bootstrapServers);

        // var config = new ProducerConfig
        // {
        //     BootstrapServers = bootstrapServers
        // };

        // var producer = new ProducerBuilder<string, string>(config).Build();

        // var ret = await producer.ProduceAsync("SimpleMessage", new Message<string, string>{
        //     Key = Guid.NewGuid().ToString(),
        //     Value = "Teste :)"
        // });

        // Console.WriteLine(ret.Status);
        // Console.WriteLine(ret.Value);

        return Accepted(":)");
    }
}