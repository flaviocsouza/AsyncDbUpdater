

using AsyncDbUpdaterShared;
using MassTransit;

namespace AsyncDbUpdaterSql;

public class RegisterProductConsumer : IConsumer<RegisterProductMessage>
{
    public Task Consume(ConsumeContext<RegisterProductMessage> context)
    {
        throw new NotImplementedException();
    }
}
