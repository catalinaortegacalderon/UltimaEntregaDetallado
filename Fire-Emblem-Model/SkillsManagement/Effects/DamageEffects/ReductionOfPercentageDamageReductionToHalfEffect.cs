using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class ReductionOfPercentageDamageReductionToHalfEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        const double reductionOfPercentageDamageReduction = 0.5;
        opponentsUnit.DamageEffects.HasReductionOfPercentageReduction *= reductionOfPercentageDamageReduction;
    }
    
}