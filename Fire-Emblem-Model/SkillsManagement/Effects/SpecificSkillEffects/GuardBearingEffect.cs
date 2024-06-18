using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class GuardBearingEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        var percentage = 0.7;
        if ((!myUnit.HasStartedACombat && myUnit.IsAttacking) ||
            (!myUnit.HasBeenBeenInACombatStartedByTheOpponent && opponentsUnit.IsAttacking)) percentage = 0.4;
        myUnit.DamageEffects.PercentageReduction = myUnit.DamageEffects.PercentageReduction * percentage;
    }
}