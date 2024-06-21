using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class ReductionOfPercentualDamageReductionEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        // todo: revisar y aplicar
        // falta aplicar en ataque y resetear
        // siempre es a la mitad
        
        // TODO: BORRAR ESTO EN TODAS PARTES
        opponentsUnit.DamageEffects.PercentageReductionReduction = true;
        
        if (opponentsUnit.DamageEffects.PercentageReduction != 1 )
            opponentsUnit.DamageEffects.PercentageReduction *= 0.5;
        if (opponentsUnit.DamageEffects.PercentageReductionOpponentsFirstAttack != 1 )
            opponentsUnit.DamageEffects.PercentageReductionOpponentsFirstAttack *= 0.5;
        if (opponentsUnit.DamageEffects.PercentageReductionOpponentsFollowup != 1 )
            opponentsUnit.DamageEffects.PercentageReductionOpponentsFollowup *= 0.5;
        
        // ((1 - unit.DamageEffects.PercentageReduction) * 100) ES LO QUE SE IMPRIME
        // DEBERIA SER A Y SE IMPRIME 2A
        
    }
        
    
}