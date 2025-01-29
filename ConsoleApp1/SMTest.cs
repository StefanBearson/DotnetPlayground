using Stateless;

namespace ConsoleApp1;

internal class SMTest
{
    public StateMachine<Chest, Action> _state;

    public SMTest()
    {
        _state = new StateMachine<Chest, Action>(Chest.Locked);
        SetSmRules();
    }

    public void ChangeStatae(Chest chest)
    {
        
    }
    
    private void SetSmRules()
    {
        _state.Configure(Chest.Open)
            .Permit(Action.Close, Chest.Closed)
            .PermitIf(Action.Close, Chest.Locked, () => HaveKey);
        _state.Configure(Chest.Closed)
            .Permit(Action.Open, Chest.Open);
        _state.Configure(Chest.Locked)
            .PermitIf(Action.Open, Chest.Open, () => HaveKey)
            .IgnoreIf(Action.Open, () => !HaveKey);
    }

    public bool HaveKey
    {
        get;
        set;
    }
}