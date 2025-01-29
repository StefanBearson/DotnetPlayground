

namespace StrategyPattern;

class Program
{
    static void Main(string[] args)
    {
        var moving = new MovementStrategy(new Run());
        var fighting = new FightProcessor(Weapons.sword);

        moving.DoMovment();
        moving.ChangeMovementType(new Walk());
        moving.DoMovment();
        moving.ChangeMovementType(new Swim()); 
        moving.DoMovment();
        moving.ChangeMovementType(new Driving());
        moving.ChangeMovementType(new Walk());
        
        fighting.Attack();
        fighting.Defend();
        fighting.ChangeWeapon(Weapons.bow);
        fighting.Attack();
        fighting.Defend();
        
        moving.DoMovment();
    }
}