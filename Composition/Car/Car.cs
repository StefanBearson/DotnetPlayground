using Composition.CarParts.Engine;
using Composition.CarParts.Wheel;
namespace Composition.Car;

public class Car
{
    static int NextId = 1;

    public int Id { get; } = NextId++;
    public string UniqueName { get;} = Guid.NewGuid().ToString();
    public int Speed {get ; set;}
    IEngine _engine {get ; set;}
    IWheel _wheel {get ; set;}
    
    public Car(IEngine engine, IWheel wheel)
    {
        _engine = engine;
        _wheel = wheel;
    }
    
    public void Drive()
    {
        _engine.Start();
        _wheel.Rotate();
    }

    public void ChangeWheel(IWheel wheel)
    {
        _wheel = wheel;
    }
    public void CheckSpeed()
    {
        if (Speed > _engine.MaxSpeed)
        {
            Speed = _engine.MaxSpeed;
        }

        WriteLine($"Current speed: {Speed}");
    }

    public override bool Equals(object? obj)
    {
        if(obj == null || GetType() != obj.GetType()) return false;

        Car other = (Car)obj;
        return UniqueName == other.UniqueName ;
    }

    public override int GetHashCode()
    {
        return Id;
    }
}

public class RunTest
{
    
    
    public async Task Run()
    {
        CancellationTokenSource _cts = new();
        var test = await Task.WhenAny(MSSQL(_cts.Token), Redis(_cts.Token)).Result;
        Console.WriteLine($"Waiting for the first task to complete: {test}");
    }

    async Task<string> MSSQL(CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        await Task.Delay(3000);
        Console.WriteLine("Get Data from MSSQL");
        
        return "MSSQL";
    }

    async Task<string> Redis(CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        await Task.Delay(5000);
        Console.WriteLine("Get Data from Redis");

        return "Redis";
    }
}