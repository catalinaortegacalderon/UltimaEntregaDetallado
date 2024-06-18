using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;

public class MyHpIsBiggerThanCondition : Condition
{
    private readonly double _amount;

    public MyHpIsBiggerThanCondition(double amount)
    {
        _amount = amount;
    }

    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        return Math.Round((double)myUnit.Hp / myUnit.MaxHp, 2) >= _amount;
    }
}