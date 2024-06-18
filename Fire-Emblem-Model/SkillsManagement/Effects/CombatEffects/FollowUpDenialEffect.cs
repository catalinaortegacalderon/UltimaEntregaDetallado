using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.CombatEffects;

public class FollowUpDenialEffect: Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        myUnit.CombatEffects.HasFollowUpDenial = true;
        myUnit.CombatEffects.AmountOfEffectsThatDenyFollowup++;
    }
}