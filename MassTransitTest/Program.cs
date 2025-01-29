using MassTransit;
using MassTransitTest;

//add configuration from appsettings.json
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);

// builder.Configuration.AddConfiguration(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddSingleton<ITestDI, TestDI>();

builder.Services.Configure<DiSettings>(configuration.GetSection("DiSettings"));
builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    x.AddConsumer<CurrentTimeConsumer>();
    
    x.UsingInMemory((context, config) =>
    {
        config.ConfigureEndpoints(context);
    });
    // x.UsingRabbitMq((context, cfg) =>
    // {
    //     cfg.Host("localhost", "/", h =>
    //     {
    //         h.Username("guest");
    //         h.Password("guest");
    //     });
    // });
});

builder.Services.AddHostedService<MessagePublisher>();
builder.Services.AddHostedService<Counter>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.Run();
