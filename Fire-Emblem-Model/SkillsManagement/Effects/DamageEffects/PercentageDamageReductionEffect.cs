using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class PercentageDamageReductionEffect : Effect
{
    private double _percentage;
    private readonly DamageEffectCategory _type;

    public PercentageDamageReductionEffect(double amount, DamageEffectCategory type)
    {
        _percentage = amount;
        _type = type;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        var finalPercentage = _percentage;
        
        Console.WriteLine("paso por apply effect percentage reduction");
        if (myUnit.DamageEffects.HasReductionOfPercentageReduction)
        {
           finalPercentage = GetNewPercentage();
        }
        
        if (_type == DamageEffectCategory.All)
        {
            myUnit.DamageEffects.PercentageReduction *= finalPercentage;
        }
        else if (_type == DamageEffectCategory.FirstAttack)
        {
            myUnit.DamageEffects.PercentageReductionOpponentsFirstAttack *= finalPercentage;
        }
        
        else if (_type == DamageEffectCategory.FollowUp)
        {
            myUnit.DamageEffects.PercentageReductionOpponentsFollowup *= finalPercentage;
        }
    }
    
    private double GetNewPercentage()
    {
        Console.WriteLine("_percentaje inicial " + _percentage);
        var initialReduction = 1 - _percentage;
        var newReduction = initialReduction / 2;
        var newPercentage = 1 - newReduction;
        Console.WriteLine("percentaje final " + newPercentage);
        return newPercentage;
    }
}