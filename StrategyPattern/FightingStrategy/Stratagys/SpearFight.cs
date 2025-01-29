namespace StrategyPattern.Fighting;

class SpearFight : IFightStrategy
{
    public void attack()
    {
        Console.WriteLine("I am attacking with a spear");
    }

    public void defend()
    {
        Console.WriteLine("I am defending with a spear");
    }
}