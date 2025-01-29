using MassTransit;

namespace MassTransitTest;

public class MessagePublisher(IBus bus, ILogger<MessagePublisher> logger, ITestDI testDi) : BackgroundService
{
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await bus.Publish(
                new CurrentTime()
                {
                    Value = $"This is a test message at {DateTime.Now}"
                }, stoppingToken);
            logger.LogInformation("Message published");
            testDi.Print();
            await Task.Delay(2000, stoppingToken);
        }
    }
}