using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem;

namespace ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;


public class CompareTotalSpdAddingSpdToTheOpponent : SecondCategoryCondition
{
    private readonly int _amountToAdd;
        
    public CompareTotalSpdAddingSpdToTheOpponent(int amountToAdd)
    {
        _amountToAdd = amountToAdd;
    }
    
    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        var myTotalSpd = TotalStatGetter.GetTotal( StatType.Spd, myUnit);
        var opponentsTotalSpd = TotalStatGetter.GetTotal( StatType.Spd, opponentsUnit);

        return myTotalSpd >= opponentsTotalSpd + _amountToAdd;
    }
}