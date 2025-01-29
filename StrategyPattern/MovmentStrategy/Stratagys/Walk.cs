namespace StrategyPattern.Movment;

class Walk : IStrategy
{
    public void Init()
    {
        Console.WriteLine("I am starting walking");
    }

    public void DoThings()
    {
        Console.WriteLine("I am walking");
    }
}