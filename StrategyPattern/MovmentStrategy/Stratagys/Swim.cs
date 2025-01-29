namespace StrategyPattern.Movment;

class Swim : IStrategy
{
    public void Init()
    {
        Console.WriteLine("I am starting swimming");
    }
    public void DoThings()
    {
        Console.WriteLine("I am swimming");
    }
}