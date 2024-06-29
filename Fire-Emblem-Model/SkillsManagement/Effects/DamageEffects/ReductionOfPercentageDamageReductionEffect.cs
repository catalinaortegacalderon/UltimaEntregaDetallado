using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class ReductionOfPercentageDamageReductionEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        Console.WriteLine("ACTIVANDO REDUCTION OF REDUCTION");
        opponentsUnit.DamageEffects.HasReductionOfPercentageReduction = true;
    }
    
}