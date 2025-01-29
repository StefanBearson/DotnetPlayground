namespace GrowingStateMashine;


enum Chest
{
    Open,
    Closed,
    Locked
}

enum Action
{
    Open,
    Close
}

internal class Demo
{
    private Chest _chest = Chest.Locked;
    public Demo()
    {
        
    }
    public void changeState(Action action, bool haveKey)
    {
        _chest = Manipulate(_chest, action, haveKey);
    }
    private static Chest Manipulate(Chest chest, Action action, bool haveKey) =>
        (chest, action, haveKey) switch
        {
            (Chest.Closed, Action.Open, _) => Chest.Open,
            (Chest.Locked, Action.Open, true) => Chest.Open,
            (Chest.Open, Action.Close, true) => Chest.Locked,
            (Chest.Open, Action.Close, false) => Chest.Closed,
            _ => chest
        };

    public override string ToString()
    {
        return $"the chest is {_chest}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        var chest = new Demo();
        
        Console.WriteLine($"1: {chest}");
        chest.changeState(Action.Open, false);
        Console.WriteLine($"2: {chest}");
        chest.changeState(Action.Close, true);
        Console.WriteLine($"3: {chest}");
        chest.changeState(Action.Open, false);
        Console.WriteLine($"3: {chest}");

    }
}


