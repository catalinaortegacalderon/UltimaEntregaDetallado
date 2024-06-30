using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;

public class ChangeHpInEffect : Effect
{
    public ChangeHpInEffect(int amount)
    {
        Amount = amount;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        if (!myUnit.ActiveBonus.HpBonusActivated)
        {
            myUnit.Hp += Amount;
            myUnit.MaxHp += Amount;
            myUnit.ActiveBonus.HpBonusActivated = true;
        }
    }
}