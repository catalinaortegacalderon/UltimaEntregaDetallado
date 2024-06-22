using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class ReductionOfPercentageDamageReductionEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        // todo: revisar y aplicar
        // falta aplicar en ataque y resetear
        // siempre es a la mitad
        
        // TODO: BORRAR ESTO EN TODAS PARTES
        opponentsUnit.DamageEffects.PercentageReductionReduction = true;
        
        if (opponentsUnit.DamageEffects.PercentageReduction != 1 )
            opponentsUnit.DamageEffects.PercentageReduction = 
                GetNewValue(opponentsUnit.DamageEffects.PercentageReduction);
        if (opponentsUnit.DamageEffects.PercentageReductionOpponentsFirstAttack != 1)
            opponentsUnit.DamageEffects.PercentageReductionOpponentsFirstAttack =
                GetNewValue(opponentsUnit.DamageEffects.PercentageReductionOpponentsFirstAttack);
        if (opponentsUnit.DamageEffects.PercentageReductionOpponentsFollowup != 1)
            opponentsUnit.DamageEffects.PercentageReductionOpponentsFollowup =
                GetNewValue(opponentsUnit.DamageEffects.PercentageReductionOpponentsFollowup);

        // ((1 - unit.DamageEffects.PercentageReduction) * 100) ES LO QUE SE IMPRIME
        // DEBERIA SER A Y SE IMPRIME 2A

        //(1 - unit), luego x 2, luego volver a restarselo

    }

    private double GetNewValue(double currentValue)
    {
        var reduction = 1 - currentValue;
        var newReduction = reduction / 2;
        var finalDataStructureValue = 1 - newReduction;
        return finalDataStructureValue;
    }
        
    
}