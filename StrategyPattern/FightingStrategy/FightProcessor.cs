namespace StrategyPattern.Fighting;

class FightProcessor
{
    IFightStrategy _fightStrategy;
    public FightProcessor(Weapons weapon)
    {
        ChangeWeapon(weapon);
    }
    
    public void ChangeWeapon(Weapons weapon)
    {
        switch (weapon)
        {
            case Weapons.sword:
                _fightStrategy = new SwordFight();
                break;
            case Weapons.axe:
                _fightStrategy = new AxeFight();
                break;
            case Weapons.bow:
                _fightStrategy = new BowFight();
                break;
            case Weapons.spear:
                _fightStrategy = new SpearFight();
                break;
        }
    }
    
    public void Attack()
    {
        _fightStrategy.attack();
    }
    
    public void Defend()
    {
        _fightStrategy.defend();
    }
}