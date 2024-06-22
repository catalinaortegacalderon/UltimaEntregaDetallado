using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class PercentageDamageReductionEffect : Effect
{
    private readonly double _percentage;
    private readonly DamageEffectCategory _type;

    public PercentageDamageReductionEffect(double amount, DamageEffectCategory type)
    {
        _percentage = amount;
        _type = type;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        if (_type == DamageEffectCategory.All)
            myUnit.DamageEffects.PercentageReduction *= _percentage;
        else if (_type == DamageEffectCategory.FirstAttack)
            myUnit.DamageEffects.PercentageReductionOpponentsFirstAttack *= _percentage;
        else if (_type == DamageEffectCategory.FollowUp)
            myUnit.DamageEffects.PercentageReductionOpponentsFollowup *= _percentage;
    }
}