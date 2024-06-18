using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem;

namespace ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;

public class CompareTotalSpdCondition : SecondCategoryCondition
{
    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        var myTotalSpd = TotalStatGetter.GetTotal(StatType.Spd, myUnit);
        var opponentsTotalSpd = TotalStatGetter.GetTotal(StatType.Spd, opponentsUnit);

        return myTotalSpd > opponentsTotalSpd;
    }
}