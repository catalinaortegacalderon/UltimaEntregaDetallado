using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class ReductionOfPercentageDamageReductionEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        // todo: arreglar unos tests, problemas con truncar parece, esta en fotos viernes 21
        
        
        if (opponentsUnit.DamageEffects.PercentageReduction != 1 )
            opponentsUnit.DamageEffects.PercentageReduction = 
                GetNewValue(opponentsUnit.DamageEffects.PercentageReduction);
        if (opponentsUnit.DamageEffects.PercentageReductionOpponentsFirstAttack != 1)
            opponentsUnit.DamageEffects.PercentageReductionOpponentsFirstAttack =
                GetNewValue(opponentsUnit.DamageEffects.PercentageReductionOpponentsFirstAttack);
        if (opponentsUnit.DamageEffects.PercentageReductionOpponentsFollowup != 1)
            opponentsUnit.DamageEffects.PercentageReductionOpponentsFollowup =
                GetNewValue(opponentsUnit.DamageEffects.PercentageReductionOpponentsFollowup);

    }

    private double GetNewValue(double currentValue)
    {
        var reduction = 1 - currentValue;
        var newReduction = reduction / 2;
        var finalDataStructureValue = 1 - newReduction;
        return finalDataStructureValue;
    }
        
    
}