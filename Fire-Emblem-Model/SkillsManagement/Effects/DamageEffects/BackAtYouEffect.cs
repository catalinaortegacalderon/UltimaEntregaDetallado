using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class BackAtYouEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        var amount = Convert.ToInt32(Math.Truncate((myUnit.HpMax - myUnit.CurrentHp) * 0.5));
        myUnit.DamageEffects.ExtraDamage += amount;
    }
}