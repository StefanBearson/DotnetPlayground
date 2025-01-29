namespace MassTransitTest;

public class Counter : IHostedService
{
    private int counter = 1;
    
    protected async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine($"Counter {counter}");
            counter++;
            await Task.Delay(200, stoppingToken);
        }

        
        
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine($"Counter {counter}");
            counter++;
            await Task.Delay(200, cancellationToken);
            if  (counter == 10)
            {
                break;
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}