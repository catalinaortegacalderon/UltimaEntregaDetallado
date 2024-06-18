using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class PercentualDamageReductionDeterminedByResDifferenceEffect : Effect
{
    private readonly int _multiplicator;
    private readonly double _max;
    private readonly DamageEffectCategory _category;
    
    public PercentualDamageReductionDeterminedByResDifferenceEffect( int multiplicator, 
        double max, DamageEffectCategory category)
    {
        _multiplicator = multiplicator;
        _max = max;
        _category = category;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        //poner el que queda no el reducido. ej: si se reduce en 10% el amount es 0.9
        double redutionPercentage = 1;

        double myTotalRes =
                myUnit.Res + myUnit.ActiveBonus.Res * myUnit.ActiveBonusNeutralizer.Res
                           + myUnit.ActivePenalties.Res * myUnit.ActivePenaltiesNeutralizer.Res;
        double opponentsTotalRes =
                opponentsUnit.Res + opponentsUnit.ActiveBonus.Res * opponentsUnit.ActiveBonusNeutralizer.Res
                                  + opponentsUnit.ActivePenalties.Res * opponentsUnit.ActivePenaltiesNeutralizer.Res;
        redutionPercentage = 1 - (myTotalRes - opponentsTotalRes) * _multiplicator / 100;

        if (redutionPercentage < _max) redutionPercentage = _max;
        
        if (_category == DamageEffectCategory.All)
            myUnit.DamageEffects.PercentageReduction *= redutionPercentage;
        if (_category == DamageEffectCategory.FirstAttack)
            myUnit.DamageEffects.PercentageReductionOpponentsFirstAttack *= redutionPercentage;
        if (_category == DamageEffectCategory.FollowUp)
            myUnit.DamageEffects.PercentageReductionOpponentsFollowup *= redutionPercentage;
    }
}