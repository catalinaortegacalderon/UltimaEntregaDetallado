using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;

public class MyHpIsBiggerThanConstantCondition : Condition
{
    private readonly int _amount;

    public MyHpIsBiggerThanConstantCondition(int amount)
    {
        _amount = amount;
    }

    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        return myUnit.CurrentHp >= _amount;
    }
}