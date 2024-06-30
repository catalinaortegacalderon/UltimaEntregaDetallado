using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;

public class ReduceOpponentsDefInPercentajeForFirstAttackEffect : Effect
{
    private readonly double _reductionPercentage;

    public ReduceOpponentsDefInPercentajeForFirstAttackEffect(double reduction)
    {
        _reductionPercentage = reduction;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        var reduction = Convert.ToInt32(Math.Truncate(opponentsUnit.Def * _reductionPercentage));
        opponentsUnit.ActivePenalties.DefFirstAttack -= reduction;
    }
}