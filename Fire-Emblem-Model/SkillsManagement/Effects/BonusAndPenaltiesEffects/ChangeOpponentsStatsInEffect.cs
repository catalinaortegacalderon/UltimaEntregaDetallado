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
        if (_stat == StatType.Atk)
        {
            if (Amount > 0) opponentsUnit.ActiveBonus.Atk = opponentsUnit.ActiveBonus.Atk + Amount;
            if (Amount < 0) opponentsUnit.ActivePenalties.Atk = opponentsUnit.ActivePenalties.Atk + Amount;
        }
        else if (_stat == StatType.Def)
        {
            if (Amount > 0) opponentsUnit.ActiveBonus.Def = opponentsUnit.ActiveBonus.Def + Amount;
            if (Amount < 0) opponentsUnit.ActivePenalties.Def = opponentsUnit.ActivePenalties.Def + Amount;
        }
        else if (_stat == StatType.Res)
        {
            if (Amount > 0) opponentsUnit.ActiveBonus.Res = opponentsUnit.ActiveBonus.Res + Amount;
            if (Amount < 0) opponentsUnit.ActivePenalties.Res = opponentsUnit.ActivePenalties.Res + Amount;
        }
        else if (_stat == StatType.Spd)
        {
            if (Amount > 0) opponentsUnit.ActiveBonus.Spd = opponentsUnit.ActiveBonus.Spd + Amount;
            if (Amount < 0) opponentsUnit.ActivePenalties.Spd = opponentsUnit.ActivePenalties.Spd + Amount;
        }
    }
}