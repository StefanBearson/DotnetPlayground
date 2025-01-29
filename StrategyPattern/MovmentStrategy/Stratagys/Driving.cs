namespace StrategyPattern.Movment;

public class Driving : IStrategy
{
    public void Init()
    {
        Console.WriteLine("I am starting driving");
    }

    public void DoThings()
    {
        Console.WriteLine("I am driving");
    }
}