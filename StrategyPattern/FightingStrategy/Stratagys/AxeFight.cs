namespace StrategyPattern.Fighting;

class AxeFight : IFightStrategy
{
    public void attack()
    {
        Console.WriteLine("I am attacking with an axe");
    }

    public void defend()
    {
        Console.WriteLine("I am defending with an axe");
    }
}