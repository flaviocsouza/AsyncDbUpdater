using AsyncDbUpdaterShared;
using MassTransit;

namespace AsyncDbUpdaterSql;

public static class ServiceBusExtensions
{
    public static IServiceCollection AddKafkaRider(this IServiceCollection services)
    {
        
        var bootstrapServers = Environment.GetEnvironmentVariable("BOOTSTRAP_SERVERS");
        var consumerGroupId = Environment.GetEnvironmentVariable("KAFKA_CONSUMER_GROUP_ID");

        services.AddMassTransit(mt => 
        {
            mt.UsingInMemory();

            mt.AddRider(rider => 
            {
                rider.AddConsumer<SimpleTextMessageConsumer>();
                rider.AddConsumer<RegisterProductConsumer>();

                rider.UsingKafka((context, kafka) =>
                {
                    kafka.Host(bootstrapServers);

                    kafka.TopicEndpoint<SimpleTextMessage>("SimpleMessage", consumerGroupId, e => 
                    {
                        e.ConfigureConsumer<SimpleTextMessageConsumer>(context);
                    });

                    kafka.TopicEndpoint<RegisterProductMessage>("Product.Register", consumerGroupId, e => 
                    {
                        e.ConfigureConsumer<RegisterProductConsumer>(context);
                    });
                });

            });
        });
        return services;
    }

}
