using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using Fire_Emblem;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class PercentageDamageReductionDeterminedBySpdDifferenceEffect : Effect
{
    private readonly int _multiplier;
    private readonly double _max;
    private readonly DamageEffectCategory _category;
    
    public PercentageDamageReductionDeterminedBySpdDifferenceEffect( int multiplier, 
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
        if (_category == DamageEffectCategory.All)
        {
            myUnit.DamageEffects.PercentageReduction *= reductionPercentage;
            myUnit.DamageEffects.AmountOfEffectsOfPercentageReduction++;
        }
        else if (_category == DamageEffectCategory.FirstAttack)
        {
            myUnit.DamageEffects.PercentageReductionOpponentsFirstAttack *= reductionPercentage;
            myUnit.DamageEffects.AmountOfEffectsOfPercentageReductionOpponentsFirstAttack++;
        }
        
        else if (_category == DamageEffectCategory.FollowUp)
        {
            myUnit.DamageEffects.PercentageReductionOpponentsFollowup *= reductionPercentage;
            myUnit.DamageEffects.AmountOfEffectsOfPercentageReductionOpponentsFollowup++;
        }
    }

    private double CalculateReductionPercentage(Unit myUnit, Unit opponentsUnit)
    {
        double myTotalSpd = TotalStatGetter.GetTotal(StatType.Spd, myUnit);
        double opponentsTotalSpd = TotalStatGetter.GetTotal(StatType.Spd, opponentsUnit);
        double reductionPercentage = 1 - (myTotalSpd - opponentsTotalSpd) * _multiplier / 100;
        if (reductionPercentage < _max) 
            reductionPercentage = _max;
        return reductionPercentage;
    }
}