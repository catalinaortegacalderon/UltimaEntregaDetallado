using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class MastermindEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        // todo: duda, considerar atk first atack y followup?, esta bien truncado?

        var myTotalBonus = myUnit.ActiveBonus.Atk * myUnit.ActiveBonusNeutralizer.Atk
                + myUnit.ActiveBonus.Spd * myUnit.ActiveBonusNeutralizer.Spd
                + myUnit.ActiveBonus.Def * myUnit.ActiveBonusNeutralizer.Def
                + myUnit.ActiveBonus.Res * myUnit.ActiveBonusNeutralizer.Res;

        myTotalBonus = (int)(0.8 * myTotalBonus);
            
        var opponentsTotalPenalties = opponentsUnit.ActivePenalties.Atk * opponentsUnit.ActivePenaltiesNeutralizer.Atk
                + opponentsUnit.ActivePenalties.Spd * opponentsUnit.ActivePenaltiesNeutralizer.Spd
                + opponentsUnit.ActivePenalties.Def * opponentsUnit.ActivePenaltiesNeutralizer.Def
                + opponentsUnit.ActivePenalties.Res * opponentsUnit.ActivePenaltiesNeutralizer.Res;
        
        opponentsTotalPenalties = (int)(0.8 * opponentsTotalPenalties);

        myUnit.DamageEffects.ExtraDamage += (myTotalBonus + opponentsTotalPenalties);
    }
}
