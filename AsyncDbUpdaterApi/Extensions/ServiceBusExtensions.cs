using MassTransit;

namespace AsyncDbUpdaterApi;

public static class ServiceBusExtensions
{
    public static IServiceCollection AddKafkaRider(this IServiceCollection services)
    {
        
        var bootstrapServers = Environment.GetEnvironmentVariable("BOOTSTRAP_SERVERS");

        services.AddMassTransit(mt => 
        {
            mt.UsingInMemory();

            mt.AddRider(rider => 
            {
                rider.AddProducer<string, SimpleTextMessage>("SimpleMessage");

                rider.UsingKafka((context, kafka) => kafka.Host(bootstrapServers));

            });
        });

       

        return services;
    }

}
