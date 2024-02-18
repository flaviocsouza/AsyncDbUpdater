using AsyncDbUpdaterApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKafkaRider();

builder.Services.AddControllers();

var app = builder.Build();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
