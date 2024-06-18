using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;

public class ChangeStatInPercentageOnlyForFirstAttackEffect : Effect
{
    private readonly double _percentage;
    private readonly StatType _stat;

    public ChangeStatInPercentageOnlyForFirstAttackEffect(StatType stat, double percentage)
    {
        _stat = stat;
        _percentage = percentage;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        Amount = 0;
        if (_stat == StatType.Atk)
        {
            Amount = Convert.ToInt32(Math.Truncate(myUnit.Atk * _percentage));
            myUnit.ActiveBonus.AtkFirstAttack += Amount;
        }
    }
}