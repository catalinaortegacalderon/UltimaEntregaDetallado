using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class PercentualDamageReductionConsideringOpponentsHpEffect : Effect
{
    private readonly DamageEffectCategory Type;

    public PercentualDamageReductionConsideringOpponentsHpEffect(DamageEffectCategory type)
    {
        Type = type;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        var percentualReduction = opponentsUnit.CurrentHp / (double)opponentsUnit.HpMax / 2;
        percentualReduction = Math.Truncate(100.0 * percentualReduction) / 100.0;
        var finalPercentage = 1 - percentualReduction;

        if (Type == DamageEffectCategory.All)
            myUnit.DamageEffects.PercentageReduction *= finalPercentage;
        else if (Type == DamageEffectCategory.FirstAttack)
            myUnit.DamageEffects.PercentageReductionOpponentsFirstAttack *= finalPercentage;
        else if (Type == DamageEffectCategory.FollowUp)
            myUnit.DamageEffects.PercentageReductionOpponentsFollowup *= finalPercentage;
    }
}