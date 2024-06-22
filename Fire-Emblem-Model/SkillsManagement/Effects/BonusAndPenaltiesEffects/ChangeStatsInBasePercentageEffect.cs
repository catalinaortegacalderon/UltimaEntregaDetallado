using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;

public class ChangeStatsInBasePercentageEffect : Effect
{
    private readonly double _percentage;
    private readonly StatType _stat;

    public ChangeStatsInBasePercentageEffect(StatType stat, double percentage)
    {
        _percentage = percentage;
        _stat = stat;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        switch (_stat)
        {
            case StatType.Atk:
            {
                if (_percentage > 0) 
                    myUnit.ActiveBonus.Atk += (int)(_percentage * myUnit.Atk);
                if (_percentage < 0) 
                    myUnit.ActivePenalties.Atk += (int)(_percentage * myUnit.Atk);
                break;
            }
            case StatType.Def:
            {
                if (_percentage > 0) 
                    myUnit.ActiveBonus.Def += (int)(_percentage * myUnit.Def);
                if (_percentage < 0) 
                    myUnit.ActivePenalties.Def += (int)(_percentage * myUnit.Def);
                break;
            }
            case StatType.Res:
            {
                if (_percentage > 0) 
                    myUnit.ActiveBonus.Res += (int)(_percentage * myUnit.Res);
                if (_percentage < 0) 
                    myUnit.ActivePenalties.Res += (int)(_percentage * myUnit.Res);
                break;
            }
            case StatType.Spd:
            {
                if (_percentage > 0) 
                    myUnit.ActiveBonus.Spd += (int)(_percentage * myUnit.Spd);
                if (_percentage < 0) 
                    myUnit.ActivePenalties.Spd += (int)(_percentage * myUnit.Spd);
                break;
            }
        }
    }
}