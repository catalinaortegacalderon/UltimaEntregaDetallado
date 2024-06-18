using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class LunarBraceEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        // todo: fn obtener valor
        var amount = opponentsUnit.Def + opponentsUnit.ActiveBonus.Def * opponentsUnit.ActiveBonusNeutralizer.Def
                                       + opponentsUnit.ActivePenalties.Def *
                                       opponentsUnit.ActivePenaltiesNeutralizer.Def;
        myUnit.DamageEffects.ExtraDamage += (int)Math.Truncate(0.3 * amount);
    }
}