using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class WrathEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        var amount = myUnit.HpMax - myUnit.CurrentHp;
        if (amount > 30) amount = 30;
        myUnit.ActiveBonus.Atk += amount;
        myUnit.ActiveBonus.Spd += amount;
    }
}