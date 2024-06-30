using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class WrathEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        var amount = myUnit.MaxHp - myUnit.Hp;
        if (amount > 30) amount = 30;
        myUnit.ActiveBonus.Atk += amount;
        myUnit.ActiveBonus.Spd += amount;
    }
}