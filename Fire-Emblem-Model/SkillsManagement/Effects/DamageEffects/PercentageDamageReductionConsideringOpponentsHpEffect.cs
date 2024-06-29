using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class PercentageDamageReductionConsideringOpponentsHpEffect : Effect
{
    private readonly DamageEffectCategory _type;
    private const double ReductionOfPercentageDamageReduction = 0.5;

    public PercentageDamageReductionConsideringOpponentsHpEffect(DamageEffectCategory type)
    {
        _type = type;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        var percentageReduction = opponentsUnit.Hp / (double)opponentsUnit.MaxHp / 2;
        percentageReduction = Math.Truncate(100.0 * percentageReduction) / 100.0;
        
        if (myUnit.DamageEffects.HasReductionOfPercentageReduction)
            percentageReduction *= ReductionOfPercentageDamageReduction;
        
        var finalPercentage = 1 - percentageReduction;
        
        switch (_type)
        {
            case DamageEffectCategory.All:
                myUnit.DamageEffects.PercentageReduction *= finalPercentage;
                break;
            case DamageEffectCategory.FirstAttack:
                myUnit.DamageEffects.PercentageReductionOpponentsFirstAttack *= finalPercentage;
                break;
            case DamageEffectCategory.FollowUp:
                myUnit.DamageEffects.PercentageReductionOpponentsFollowup *= finalPercentage;
                break;
        }
    }
}