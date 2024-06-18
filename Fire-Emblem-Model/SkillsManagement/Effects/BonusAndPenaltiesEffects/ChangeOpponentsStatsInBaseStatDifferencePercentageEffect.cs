using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;

public class ChangeOpponentsStatsInBaseStatDifferencePercentageEffect: Effect
{
    private readonly double _percentage;
    private readonly StatType _stat;
    private readonly StatType _referenceStat;

    public ChangeOpponentsStatsInBaseStatDifferencePercentageEffect(StatType stat, double percentage, 
        StatType referenceStat)
    {
        _stat = stat;
        _percentage = percentage;
        _referenceStat = referenceStat;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        Amount = 0;
        if (_stat == StatType.Atk && _referenceStat == StatType.Def)
        {
            Amount = Convert.ToInt32(Math.Truncate((myUnit.Def - opponentsUnit.Def)
                                                    * _percentage));
            if (Amount < 0)
                Amount = 0;
            if (Amount > 8)
                Amount = 8;
            opponentsUnit.ActivePenalties.Atk -= Amount;
        }
        if (_stat == StatType.Atk && _referenceStat == StatType.Res)
        {
            Amount = Convert.ToInt32(Math.Truncate((myUnit.Res - opponentsUnit.Res)
                                                   * _percentage));
            if (Amount < 0)
                Amount = 0;
            if (Amount > 8)
                Amount = 8;
            opponentsUnit.ActivePenalties.Atk -= Amount;
        }
        if (_stat == StatType.Def && _referenceStat == StatType.Def)
        {
            Amount = Convert.ToInt32(Math.Truncate((myUnit.Def - opponentsUnit.Def)
                                                   * _percentage));
            if (Amount < 0)
                Amount = 0;
            if (Amount > 8)
                Amount = 8;
            opponentsUnit.ActivePenalties.Def -= Amount;
        }
        if (_stat == StatType.Def && _referenceStat == StatType.Res)
        {
            Amount = Convert.ToInt32(Math.Truncate((myUnit.Res - opponentsUnit.Res)
                                                   * _percentage));
            if (Amount < 0)
                Amount = 0;
            if (Amount > 8)
                Amount = 8;
            opponentsUnit.ActivePenalties.Def -= Amount;
        }
    }
}