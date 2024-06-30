using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.CombatEffects;

public class HealingEffect: Effect
{
    private readonly double _percentage;
    
    public HealingEffect(double percentage)
    {
        _percentage = percentage;
    }
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        myUnit.CombatEffects.HpRecuperationAtEveryAttack += _percentage;
    }
}