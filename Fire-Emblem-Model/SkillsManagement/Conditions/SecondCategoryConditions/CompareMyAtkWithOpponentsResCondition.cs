using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;

public class CompareMyAtkWithOpponentsResCondition : SecondCategoryCondition
{
    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        var myTotalAtk = TotalStatGetter.GetTotal(StatType.Atk, myUnit);
        var opponentsTotalRes = TotalStatGetter.GetTotal(StatType.Res, opponentsUnit);

        return myTotalAtk > opponentsTotalRes;
    }
}