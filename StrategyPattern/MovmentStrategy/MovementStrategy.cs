namespace StrategyPattern.Movment;

class MovementStrategy
{
    private IStrategy _strategy;
    public MovementStrategy(IStrategy strategy)
    {
        _strategy = strategy;
        _strategy.Init();
    }
    
    public void ChangeMovementType(IStrategy strategy)
    {
        _strategy = strategy;
        _strategy.Init();
    }

    public void DoMovment()
    {
        _strategy.DoThings();
    }
}