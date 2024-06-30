using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;

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
        const double penaltiesMultiplier = 0.8;
        
        var opponentsTotalPenalties = TotalStatGetter.GetTotalPenalties(opponentsUnit);
        opponentsTotalPenalties = (int)(penaltiesMultiplier * opponentsTotalPenalties);
        return opponentsTotalPenalties;
    }

    private static int ObtainMyTotalBonusFraction(Unit myUnit)
    {
        const double bonusMultiplier = 0.8;
        
        var myTotalBonus = TotalStatGetter.GetTotalBonus(myUnit);
        myTotalBonus = (int)(bonusMultiplier * myTotalBonus);
        return myTotalBonus;
    }
}
