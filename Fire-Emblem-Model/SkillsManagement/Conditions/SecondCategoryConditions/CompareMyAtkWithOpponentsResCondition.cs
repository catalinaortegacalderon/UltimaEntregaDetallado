using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;

public class CompareMyAtkWithOpponentsResCondition : SecondCategoryCondition
{
    // todo: agregar funcion para calcular el if final
    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        var myTotalAtk =
            myUnit.Atk + myUnit.ActiveBonus.Atk * myUnit.ActiveBonusNeutralizer.Atk
                       + myUnit.ActivePenalties.Atk * myUnit.ActivePenaltiesNeutralizer.Atk;
        var opponentsTotalRes =
            opponentsUnit.Res + opponentsUnit.ActiveBonus.Res * opponentsUnit.ActiveBonusNeutralizer.Res
                              + opponentsUnit.ActivePenalties.Res * opponentsUnit.ActivePenaltiesNeutralizer.Res;

        if (myTotalAtk > opponentsTotalRes) return true;
        return false;
    }
}