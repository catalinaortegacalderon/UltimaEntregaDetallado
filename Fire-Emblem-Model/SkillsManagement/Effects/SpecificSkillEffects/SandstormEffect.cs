using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class SandstormEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        var amount = Convert.ToInt32(Math.Truncate(1.5 * myUnit.Def)) - myUnit.Atk;
        if (amount < 0) myUnit.ActivePenalties.AtkFollowup += amount;
        else
            myUnit.ActiveBonus.AtkFollowup += amount;
    }
}