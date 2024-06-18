using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class MastermindEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        var myTotalBonusFraction = ObtainMyTotalBonusFraction(myUnit);
        var opponentsTotalPenaltiesFraction = ObtainOpponentsTotalPenaltiesFraction(opponentsUnit);

        myUnit.DamageEffects.ExtraDamage += (myTotalBonusFraction - opponentsTotalPenaltiesFraction);
    }

    private static int ObtainOpponentsTotalPenaltiesFraction(Unit opponentsUnit)
    {
        var opponentsTotalPenalties = opponentsUnit.ActivePenalties.Atk 
                                      * opponentsUnit.ActivePenaltiesNeutralizer.Atk
                                      + opponentsUnit.ActivePenalties.Spd * opponentsUnit.ActivePenaltiesNeutralizer.Spd
                                      + opponentsUnit.ActivePenalties.Def * opponentsUnit.ActivePenaltiesNeutralizer.Def
                                      + opponentsUnit.ActivePenalties.Res * opponentsUnit.ActivePenaltiesNeutralizer.Res;

        opponentsTotalPenalties = (int)(0.8 * opponentsTotalPenalties);
        return opponentsTotalPenalties;
    }

    private static int ObtainMyTotalBonusFraction(Unit myUnit)
    {
        var myTotalBonus = myUnit.ActiveBonus.Atk * myUnit.ActiveBonusNeutralizer.Atk
                           + myUnit.ActiveBonus.Spd * myUnit.ActiveBonusNeutralizer.Spd
                           + myUnit.ActiveBonus.Def * myUnit.ActiveBonusNeutralizer.Def
                           + myUnit.ActiveBonus.Res * myUnit.ActiveBonusNeutralizer.Res;

        myTotalBonus = (int)(0.8 * myTotalBonus);
        return myTotalBonus;
    }
}
