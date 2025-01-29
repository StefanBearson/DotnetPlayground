namespace StrategyPattern.Movment;

class Run : IStrategy
{
    public void Init()
    {
        Console.WriteLine("I am starting running");
    }
    public void DoThings()
    {
        Console.WriteLine("I am running");
    }
}