using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;

public class OpponentHasHpGreaterThanCondition : Condition
{
    private readonly double _percentage;

    public OpponentHasHpGreaterThanCondition(double percentage)
    {
        _percentage = percentage;
    }

    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        return opponentsUnit.CurrentHp >= opponentsUnit.HpMax * _percentage;
    }
}