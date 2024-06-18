using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;

public class ChangeStatsInBasePlusOnePointForEveryEffect : Effect
{
    private readonly int _baseIncrease;
    private readonly int _divisor;
    private readonly StatType _stat;

    public ChangeStatsInBasePlusOnePointForEveryEffect(StatType stat, int baseIncrease, int divisor)
    {
        _stat = stat;
        _divisor = divisor;
        _baseIncrease = baseIncrease;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        if (_stat == StatType.Spd)
        {
            double division = myUnit.Spd / _divisor;
            Amount = Convert.ToInt32(Math.Truncate(division));
            myUnit.ActiveBonus.Spd += Amount + _baseIncrease;
        }
    }
}