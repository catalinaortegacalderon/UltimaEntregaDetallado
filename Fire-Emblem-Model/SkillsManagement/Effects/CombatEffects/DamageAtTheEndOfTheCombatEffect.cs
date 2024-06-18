using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.CombatEffects;

public class DamageAtTheEndOfTheCombatEffect : Effect
{
    private readonly int _amount;
    
    public DamageAtTheEndOfTheCombatEffect(int amount)
    {
        _amount = amount;
    }
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        myUnit.CombatEffects.DamageAfterCombat += _amount;
    }
}