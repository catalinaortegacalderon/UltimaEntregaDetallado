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
        opponentsUnit.DamageEffects.PercentageReductionReduction = true;
    }
    
    // alternativa: ver que tengan y reducirlo, ver como se anuncia
    //if (Type == DamageEffectCategory.All)
    //myUnit.DamageEffects.PercentageReduction *= finalPercentage;
    //else if (Type == DamageEffectCategory.FirstAttack)
    //myUnit.DamageEffects.PercentageReductionOpponentsFirstAttack *= finalPercentage;
    //else if (Type == DamageEffectCategory.FollowUp)
    //myUnit.DamageEffects.PercentageReductionOpponentsFollowup *= finalPercentage;
}