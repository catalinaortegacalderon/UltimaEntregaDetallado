using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class PercentualDamageReductionEffect : Effect
{
    private readonly double percentaje;
    private readonly DamageEffectCategory Type;

    public PercentualDamageReductionEffect(double amount, DamageEffectCategory type)
    {
        percentaje = amount;
        Type = type;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        //poner el que queda no el reducido. ej: si se reduce en 10% el amount es 0.9
        if (Type == DamageEffectCategory.All)
            myUnit.DamageEffects.PercentageReduction = myUnit.DamageEffects.PercentageReduction * percentaje;
        else if (Type == DamageEffectCategory.FirstAttack)
            myUnit.DamageEffects.PercentageReductionOpponentsFirstAttack =
                myUnit.DamageEffects.PercentageReductionOpponentsFirstAttack * percentaje;
        else if (Type == DamageEffectCategory.FollowUp)
            myUnit.DamageEffects.PercentageReductionOpponentsFollowup =
                myUnit.DamageEffects.PercentageReductionOpponentsFollowup * percentaje;
    }
}