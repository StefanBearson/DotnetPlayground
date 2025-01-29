namespace StrategyPattern.Fighting;

class BowFight : IFightStrategy
{
    public void attack()
    {
        Console.WriteLine("I am attacking with a bow");
    }

    public void defend()
    {
        Console.WriteLine("I am defending with a bow");
    }
}