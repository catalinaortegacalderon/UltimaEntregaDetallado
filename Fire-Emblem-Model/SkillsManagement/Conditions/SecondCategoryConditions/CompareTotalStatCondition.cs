using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;

public class CompareTotalStatCondition : SecondCategoryCondition
{
    private readonly StatType _stat;
    public CompareTotalStatCondition(StatType stat)
    {
        _stat = stat;
    }
    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        var myTotalStat = TotalStatGetter.GetTotal(_stat, myUnit);
        var opponentsTotalStat = TotalStatGetter.GetTotal(_stat, opponentsUnit);

        return myTotalStat > opponentsTotalStat;
    }
}