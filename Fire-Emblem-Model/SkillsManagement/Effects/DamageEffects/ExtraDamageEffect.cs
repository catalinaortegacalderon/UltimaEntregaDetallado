using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class ExtraDamageEffect : Effect
{
    private readonly int _amount;
    private readonly DamageEffectCategory _type;

    public ExtraDamageEffect(int amount, DamageEffectCategory type)
    {
        _amount = amount;
        _type = type;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        if (_type == DamageEffectCategory.All)
            myUnit.DamageEffects.ExtraDamage += _amount;
        else if (_type == DamageEffectCategory.FirstAttack)
            myUnit.DamageEffects.ExtraDamageFirstAttack += _amount;
        else if (_type == DamageEffectCategory.FollowUp)
            myUnit.DamageEffects.ExtraDamageFollowup += _amount;
    }
}