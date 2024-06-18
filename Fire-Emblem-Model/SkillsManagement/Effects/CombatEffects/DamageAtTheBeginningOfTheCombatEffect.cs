using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.CombatEffects;

public class DamageAtTheBeginningOfTheCombatEffect : Effect
{
    private readonly int _amount;
    
    public DamageAtTheBeginningOfTheCombatEffect(int amount)
    {
        _amount = amount;
    }
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        myUnit.CombatEffects.DamageBeforeCombat += _amount;
    }
}