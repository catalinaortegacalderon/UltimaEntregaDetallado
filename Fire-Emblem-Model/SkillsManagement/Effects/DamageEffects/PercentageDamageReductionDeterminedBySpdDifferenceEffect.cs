using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using Fire_Emblem;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class PercentageDamageReductionDeterminedBySpdDifferenceEffect : Effect
{
    private readonly double _multiplier;
    private readonly double _max;
    private readonly DamageEffectCategory _category;
    private const double ReductionOfPercentageDamageReduction = 0.5;
    
    public PercentageDamageReductionDeterminedBySpdDifferenceEffect(int multiplier, 
        double max, DamageEffectCategory category)
    {
        _multiplier = multiplier;
        _max = max;
        _category = category;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        var reductionPercentage = CalculateReductionPercentage(myUnit, opponentsUnit);
        ApplyReductionPercentage(myUnit, reductionPercentage);
    }

    private void ApplyReductionPercentage(Unit myUnit, double reductionPercentage)
    {
        switch (_category)
        {
            case DamageEffectCategory.All:
                myUnit.DamageEffects.PercentageReduction *= reductionPercentage;
                break;
            case DamageEffectCategory.FirstAttack:
                myUnit.DamageEffects.PercentageReductionOpponentsFirstAttack *= reductionPercentage;
                break;
            case DamageEffectCategory.FollowUp:
                myUnit.DamageEffects.PercentageReductionOpponentsFollowup *= reductionPercentage;
                break;
        }
    }

    private double CalculateReductionPercentage(Unit myUnit, Unit opponentsUnit)
    {
        double myTotalSpd = TotalStatGetter.GetTotal(StatType.Spd, myUnit);
        double opponentsTotalSpd = TotalStatGetter.GetTotal(StatType.Spd, opponentsUnit);
        
        var newMultiplier = _multiplier;

        if (myUnit.DamageEffects.HasReductionOfPercentageReduction)
            newMultiplier *= ReductionOfPercentageDamageReduction;
        
        double reductionPercentage = 1 - (myTotalSpd - opponentsTotalSpd) * newMultiplier / 100;
        
        if (reductionPercentage < _max) 
            reductionPercentage = _max;
        
        return reductionPercentage;
    }
}