using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;

public class CompareTotalResCondition : SecondCategoryCondition
{
    // todo: funcion
    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        var myTotalRes =
            myUnit.Res + myUnit.ActiveBonus.Res * myUnit.ActiveBonusNeutralizer.Res
                       + myUnit.ActivePenalties.Res * myUnit.ActivePenaltiesNeutralizer.Res;
        var opponentsTotalRes =
            opponentsUnit.Res + opponentsUnit.ActiveBonus.Res * opponentsUnit.ActiveBonusNeutralizer.Res
                              + opponentsUnit.ActivePenalties.Res * opponentsUnit.ActivePenaltiesNeutralizer.Res;

        if (myTotalRes > opponentsTotalRes) return true;
        return false;
    }
}