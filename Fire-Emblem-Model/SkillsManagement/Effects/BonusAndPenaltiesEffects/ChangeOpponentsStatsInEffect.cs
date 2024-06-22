using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;

public class ChangeOpponentsStatsInEffect : Effect
{
    private readonly StatType _stat;

    public ChangeOpponentsStatsInEffect(StatType stat, int amount)
    {
        Amount = amount;
        _stat = stat;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        switch (_stat)
        {
            case StatType.Atk:
            {
                if (Amount > 0) opponentsUnit.ActiveBonus.Atk += Amount;
                if (Amount < 0) opponentsUnit.ActivePenalties.Atk += Amount;
                break;
            }
            case StatType.Def:
            {
                if (Amount > 0) opponentsUnit.ActiveBonus.Def += Amount;
                if (Amount < 0) opponentsUnit.ActivePenalties.Def += Amount;
                break;
            }
            case StatType.Res:
            {
                if (Amount > 0) opponentsUnit.ActiveBonus.Res += Amount;
                if (Amount < 0) opponentsUnit.ActivePenalties.Res += Amount;
                break;
            }
            case StatType.Spd:
            {
                if (Amount > 0) opponentsUnit.ActiveBonus.Spd += Amount;
                if (Amount < 0) opponentsUnit.ActivePenalties.Spd += Amount;
                break;
            }
        }
    }
}