using MassTransit;

namespace MassTransitTest;

public class CurrentTimeConsumer(ILogger<CurrentTimeConsumer> logger) : IConsumer<CurrentTime>
{
    public Task Consume(ConsumeContext<CurrentTime> context)
    {
        logger.LogInformation(context.Message.Value, nameof(CurrentTimeConsumer));
        return Task.CompletedTask;
    }
}