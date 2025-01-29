namespace StrategyPattern.Fighting;

class SwordFight : IFightStrategy
{
    public void attack()
    {
        Console.WriteLine("I am attacking with a sword");
    }

    public void defend()
    {
        Console.WriteLine("I am defending with a sword");
    }
}