using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;

public class ReduceOpponentsResInPercentageForFirstAttackEffect : Effect
{
    private readonly double _reductionPercentage;

    public ReduceOpponentsResInPercentageForFirstAttackEffect(double reduction)
    {
        _reductionPercentage = reduction;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        var reduction = Convert.ToInt32(Math.Truncate(opponentsUnit.Res * _reductionPercentage));
        opponentsUnit.ActivePenalties.ResFirstAttack -= reduction;
    }
}