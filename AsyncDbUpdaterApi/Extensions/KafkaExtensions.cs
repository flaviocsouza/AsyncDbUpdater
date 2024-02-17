using MassTransit;

namespace AsyncDbUpdaterApi;

public static class KafkaExtensions
{
    public static IServiceCollection AddKafka(this IServiceCollection services)
    {
        
        var bootstrapServers = Environment.GetEnvironmentVariable("BOOTSTRAP_SERVERS");

        services.AddMassTransit(mt => 
        {
            mt.UsingInMemory();

            mt.AddRider(rider => 
            {
                //Add Producers
                rider.AddProducer<string, SimpleTextMessage>("SimpleMessage");

                rider.UsingKafka((context, kafka) => kafka.Host(bootstrapServers));

            });
        });

       

        return services;
    }

}
