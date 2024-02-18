
using MassTransit;

namespace AsyncDbUpdaterSql;

public class SimpleTextMessageConsumer : IConsumer<SimpleTextMessage>
{
    public Task Consume(ConsumeContext<SimpleTextMessage> context)
    {
        Console.WriteLine("---CONSUMIDO CORRETAMENTE---");
        Console.WriteLine(context.Message.MessageText);

        return Task.CompletedTask;
    }
}
