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
        var finalPercentage = _percentage;
        
        if (myUnit.DamageEffects.HasReductionOfPercentageReduction)
        {
           finalPercentage = GetNewPercentage();
        }
        
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
    
    private double GetNewPercentage()
    {
        var initialReduction = 1 - _percentage;
        var newReduction = initialReduction / 2;
        var newPercentage = 1 - newReduction;
        return newPercentage;
    }
}