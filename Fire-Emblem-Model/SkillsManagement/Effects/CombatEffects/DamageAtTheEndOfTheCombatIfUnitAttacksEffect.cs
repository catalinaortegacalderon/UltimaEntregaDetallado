using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.CombatEffects;


public class DamageAtTheEndOfTheCombatIfUnitAttacksEffect : Effect
{
    private readonly int _amount;
    
    public DamageAtTheEndOfTheCombatIfUnitAttacksEffect(int amount)
    {
        _amount = amount;
    }
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        myUnit.CombatEffects.DamageAfterCombatIfUnitAttacks += _amount;
    }
}