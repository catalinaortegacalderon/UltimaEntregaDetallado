using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class PercentageDamageReductionDeterminedByResDifferenceEffect : Effect
{
    private readonly double _multiplier;
    private readonly double _max;
    private readonly DamageEffectCategory _category;
    
    public PercentageDamageReductionDeterminedByResDifferenceEffect( int multiplier, 
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
        double myTotalRes = TotalStatGetter.GetTotal(StatType.Res, myUnit);
        double opponentsTotalRes = TotalStatGetter.GetTotal(StatType.Res, opponentsUnit);
        
        var reductionPercentage = 1 - (myTotalRes - opponentsTotalRes) * _multiplier / 100;
        
        if (reductionPercentage < _max) 
            reductionPercentage = _max;
        
        reductionPercentage = 1 - (1- reductionPercentage) * myUnit.DamageEffects.ReductionOfPercentageReduction;
        
        return reductionPercentage;
    }

}