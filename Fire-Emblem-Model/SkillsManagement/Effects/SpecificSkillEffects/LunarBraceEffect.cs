using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class LunarBraceEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        var amount = TotalStatGetter.GetTotal(StatType.Def, opponentsUnit);
        myUnit.DamageEffects.ExtraDamage += (int)Math.Truncate(0.3 * amount);
    }
}