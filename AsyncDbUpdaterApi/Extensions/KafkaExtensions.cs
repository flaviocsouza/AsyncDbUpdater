using MassTransit;

namespace AsyncDbUpdaterApi;

public static class KafkaExtensions
{
    public static IServiceCollection AddKafka(this IServiceCollection services)
    {
        services.AddMassTransit(mt => 
        {
            mt.UsingInMemory();

            mt.AddRider(rider => 
            {
                //Add Producers
                rider.AddProducer<string, SimpleTextMessage>("SimpleTextMessageTopic");


                rider.UsingKafka((context, kafka) =>
                {
                    kafka.ClientId = "AsyncDbUpdaterApi";
                    kafka.Host("http://localhost:9092/");
                });
            });
        });       

        return services;
    }

}
