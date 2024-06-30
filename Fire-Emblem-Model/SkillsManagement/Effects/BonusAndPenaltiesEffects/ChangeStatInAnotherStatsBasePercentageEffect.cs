using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;

public class ChangeStatInAnotherStatsBasePercentageEffect : Effect
{
private readonly double _percentage;
private readonly StatType _stat;
private readonly StatType _referenceStat;

public ChangeStatInAnotherStatsBasePercentageEffect(StatType stat, double percentage, 
    StatType referenceStat)
{
    _percentage = percentage;
    _referenceStat = referenceStat;
    _stat = stat;
}

public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
{
    if (_stat == StatType.Atk && _referenceStat == StatType.Spd)
    {
        if (_percentage > 0) 
            myUnit.ActiveBonus.Atk += (int)(_percentage * myUnit.Spd);
        if (_percentage < 0) 
            myUnit.ActivePenalties.Atk += (int)(_percentage * myUnit.Spd);
    }
}
}