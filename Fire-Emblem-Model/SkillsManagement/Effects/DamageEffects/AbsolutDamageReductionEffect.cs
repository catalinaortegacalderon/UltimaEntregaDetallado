using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class AbsolutDamageReductionEffect : Effect
{
    public AbsolutDamageReductionEffect(int amount)
    {
        Amount = amount;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        myUnit.DamageEffects.AbsolutDamageReduction -= Amount;
    }
}