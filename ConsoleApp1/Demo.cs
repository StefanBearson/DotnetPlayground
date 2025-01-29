namespace ConsoleApp1;

internal class Demo
{
    private Chest _chest = Chest.Locked;
    private bool AreThereAnyGoldLeft = true;
    
    
    public Demo()
    {
        
    }

    public string TryTakeLoot()
    {
        var ChestState = new ChestState
        {
            Chest = _chest,
            AreThereAnyGoldLeft = AreThereAnyGoldLeft
        };
        
        //This is sort of durty, but it works, The switch statement is not Pure, it has a side effect!
        return ChestState switch
        {
            { Chest: Chest.Closed } => "Sorry the chest is closed",
            { Chest: Chest.Locked } => "Sorry the chest is locked",
            { Chest: Chest.Open, AreThereAnyGoldLeft: true} => TakeAllTheGold(),
            { Chest: Chest.Open, AreThereAnyGoldLeft: false}=> "Sorry the chest is empty",
            _ => "How the hell did you come here, the Enum had only three options!"
        };
    }
    
    private string TakeAllTheGold()
    {
        AreThereAnyGoldLeft = false;
        return "Take All The Gold!";
    }
    public void ChangeState(Action action, bool haveKey)
    {
        _chest = StateController(_chest, action, haveKey);
    }
    
    private Chest StateController(Chest chest, Action action, bool haveKey) =>
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