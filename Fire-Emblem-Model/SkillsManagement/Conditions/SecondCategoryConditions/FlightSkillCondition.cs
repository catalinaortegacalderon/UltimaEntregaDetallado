using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;

public class FlightSkillCondition : SecondCategoryCondition
{
    private readonly StatType _referenceStat;
    public FlightSkillCondition(StatType referenceStat)
    {
        _referenceStat = referenceStat;
    }
    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {

        var myTotalSpd = TotalStatGetter.GetTotal(StatType.Spd, myUnit);
        var opponentsTotalSpd = TotalStatGetter.GetTotal(StatType.Spd, opponentsUnit);

        var myAmountToAdd = 0;
        var opponentsAmountToAdd = 0;

        switch (_referenceStat)
        {
            case StatType.Def:
                myAmountToAdd = TotalStatGetter.GetTotal(StatType.Def, myUnit);
                opponentsAmountToAdd = TotalStatGetter.GetTotal(StatType.Def, opponentsUnit);
                break;
            case StatType.Res:
                myAmountToAdd = TotalStatGetter.GetTotal(StatType.Res, myUnit);
                opponentsAmountToAdd = TotalStatGetter.GetTotal(StatType.Res, opponentsUnit);
                break;
        }

        return (myTotalSpd + myAmountToAdd > opponentsTotalSpd + opponentsAmountToAdd);
    }
}