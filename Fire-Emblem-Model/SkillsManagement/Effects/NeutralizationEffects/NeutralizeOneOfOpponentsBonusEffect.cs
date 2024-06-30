using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.NeutralizationEffects;

public class NeutralizeOneOfOpponentsBonusEffect : Effect
{
    private readonly StatType _stat;

    public NeutralizeOneOfOpponentsBonusEffect(StatType stat)
    {
        _stat = stat;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        switch (_stat)
        {
            case StatType.Atk:
                opponentsUnit.ActiveBonusNeutralizer.Atk = 0;
                break;
            case StatType.Def:
                opponentsUnit.ActiveBonusNeutralizer.Def = 0;
                break;
            case StatType.Res:
                opponentsUnit.ActiveBonusNeutralizer.Res = 0;
                break;
            case StatType.Spd:
                opponentsUnit.ActiveBonusNeutralizer.Spd = 0;
                break;
        }
    }
}