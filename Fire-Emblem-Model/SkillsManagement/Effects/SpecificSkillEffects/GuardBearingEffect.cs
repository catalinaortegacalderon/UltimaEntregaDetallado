using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class GuardBearingEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        // todo: arreglar
        // todo: encapsular constantes
        var percentage = 0.7;
        
        if(myUnit.DamageEffects.HasReductionOfPercentageReduction)
        {
            percentage = 0.85;
        }

        if (IsTheFirstTimeMyUnitsStartsTheCombat(myUnit) ||
            IsTheFirstTimeMyUnitIsInACombatStartedByTheOpponent(myUnit, opponentsUnit))
        {
            percentage = 0.4;
            if(myUnit.DamageEffects.HasReductionOfPercentageReduction)
            {
                percentage = 0.7;
            }
        }
        
        myUnit.DamageEffects.PercentageReduction *= percentage;
    }

    private static bool IsTheFirstTimeMyUnitsStartsTheCombat(Unit myUnit)
    {
        return !myUnit.HasStartedACombat && myUnit.IsAttacking;
    }
    
    private static bool IsTheFirstTimeMyUnitIsInACombatStartedByTheOpponent(Unit myUnit, Unit opponentsUnit)
    {
        return !myUnit.HasBeenBeenInACombatStartedByTheOpponent && opponentsUnit.IsAttacking;
    }
}