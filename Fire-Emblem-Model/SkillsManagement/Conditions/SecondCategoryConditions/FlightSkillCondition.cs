using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem;

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

        int myAmountToAdd = 0;
        int opponentsAmountToAdd = 0;

        if (_referenceStat == StatType.Def)
        {
            myAmountToAdd = TotalStatGetter.GetTotal(StatType.Def, myUnit);
            opponentsAmountToAdd = TotalStatGetter.GetTotal(StatType.Def, opponentsUnit);
        }
        if (_referenceStat == StatType.Res)
        {
            myAmountToAdd = TotalStatGetter.GetTotal(StatType.Res, myUnit);
            opponentsAmountToAdd = TotalStatGetter.GetTotal(StatType.Res, opponentsUnit);
        }

        return (myTotalSpd + myAmountToAdd > opponentsTotalSpd + opponentsAmountToAdd);
    }
}