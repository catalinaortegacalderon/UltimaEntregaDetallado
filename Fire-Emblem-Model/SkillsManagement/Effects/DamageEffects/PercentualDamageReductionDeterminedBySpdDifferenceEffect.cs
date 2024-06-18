using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class PercentualDamageReductionDeterminedBySpdDifferenceEffect : Effect
{
    private readonly int _multiplicator;
    private readonly double _max;
    private readonly DamageEffectCategory _category;
    
    // todo: lo de abajo recibe muchos args
    public PercentualDamageReductionDeterminedBySpdDifferenceEffect( int multiplicator, 
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

        double myTotalSpd =
                myUnit.Spd + myUnit.ActiveBonus.Spd * myUnit.ActiveBonusNeutralizer.Spd
                           + myUnit.ActivePenalties.Spd * myUnit.ActivePenaltiesNeutralizer.Spd;
        double opponentsTotalSpd =
                opponentsUnit.Spd + opponentsUnit.ActiveBonus.Spd * opponentsUnit.ActiveBonusNeutralizer.Spd
                                  + opponentsUnit.ActivePenalties.Spd * opponentsUnit.ActivePenaltiesNeutralizer.Spd;
        redutionPercentage = 1 - (myTotalSpd - opponentsTotalSpd) * _multiplicator / 100;

        if (redutionPercentage < _max) redutionPercentage = _max;
        
        if (_category == DamageEffectCategory.All)
            myUnit.DamageEffects.PercentageReduction *= redutionPercentage;
        if (_category == DamageEffectCategory.FollowUp)
            myUnit.DamageEffects.PercentageReductionOpponentsFollowup *= redutionPercentage;
    }
}