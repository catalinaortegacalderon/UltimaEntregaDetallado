using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.CombatEffects;

public class OpponentFollowUpDenialEffect: Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        opponentsUnit.CombatEffects.HasFollowUpDenial = true;
        opponentsUnit.CombatEffects.AmountOfEffectsThatDenyFollowup++;
    }
}