using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.NeutralizationEffects;

public class NeutralizeOneOfMyPenaltiesEffect : Effect
{
    private readonly StatType _stat;

    public NeutralizeOneOfMyPenaltiesEffect(StatType stat)
    {
        _stat = stat;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        switch (_stat)
        {
            case StatType.Atk:
                myUnit.ActivePenaltiesNeutralizer.Atk = 0;
                break;
            case StatType.Def:
                myUnit.ActivePenaltiesNeutralizer.Def = 0;
                break;
            case StatType.Res:
                myUnit.ActivePenaltiesNeutralizer.Res = 0;
                break;
            case StatType.Spd:
                myUnit.ActivePenaltiesNeutralizer.Spd = 0;
                break;
        }
    }
}