using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;

public class CompareBaseStatsMinusAmountCondition : Condition
{
    private readonly double _amount;
    private readonly StatType _stat;

    public CompareBaseStatsMinusAmountCondition( StatType stat, double amount)
    {
        _amount = amount;
        _stat = stat;
    }

    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        return _stat switch
        {
            StatType.Atk => myUnit.Atk >= opponentsUnit.Atk - _amount,
            StatType.Spd => myUnit.Spd >= opponentsUnit.Spd - _amount,
            StatType.Def => myUnit.Def >= opponentsUnit.Def - _amount,
            _ => myUnit.Res >= opponentsUnit.Res - _amount
        };
    }
}