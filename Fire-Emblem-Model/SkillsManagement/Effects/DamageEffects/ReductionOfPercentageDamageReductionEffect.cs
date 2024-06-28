using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class ReductionOfPercentageDamageReductionEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        // todo: arreglar unos tests, problemas con truncar parece, esta en fotos viernes 21
        // tengo que truncar
        //return;
        // todo: hacer lo de pinto, foto jueves 27, es por cada reduccion individual
        
        
        if (opponentsUnit.DamageEffects.PercentageReduction != 1 )
            opponentsUnit.DamageEffects.PercentageReduction = 
                GetNewValue(opponentsUnit.DamageEffects.PercentageReduction, 
                    opponentsUnit.DamageEffects.AmountOfEffectsOfPercentageReduction);
        if (opponentsUnit.DamageEffects.PercentageReductionOpponentsFirstAttack != 1)
            opponentsUnit.DamageEffects.PercentageReductionOpponentsFirstAttack =
                GetNewValue(opponentsUnit.DamageEffects.PercentageReductionOpponentsFirstAttack, 
                    opponentsUnit.DamageEffects.AmountOfEffectsOfPercentageReductionOpponentsFirstAttack);
        if (opponentsUnit.DamageEffects.PercentageReductionOpponentsFollowup != 1)
            opponentsUnit.DamageEffects.PercentageReductionOpponentsFollowup =
                GetNewValue(opponentsUnit.DamageEffects.PercentageReductionOpponentsFollowup, 
                    opponentsUnit.DamageEffects.AmountOfEffectsOfPercentageReductionOpponentsFollowup);

    }

    private double GetNewValue(double currentValue, int amountOfEffects)
    {
        // todo: encapsular 0.5
        // parece que no funciona
        // todo: hacer lo de pinto
        // esto se hará al principio, ver prioridades bien
        var reduction = 1 - currentValue;
        var newReduction = reduction * Math.Pow(0.5, amountOfEffects) ;
        var finalDataStructureValue = 1 - newReduction;
        return finalDataStructureValue;
    }
        
    
}