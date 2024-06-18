using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.NeutralizationEffects;

public class NeutralizeOneOfMyBonusEffect : Effect
{
    private readonly StatType _stat;

    public NeutralizeOneOfMyBonusEffect(StatType stat)
    {
        _stat = stat;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        if (_stat == StatType.Atk) myUnit.ActiveBonusNeutralizer.Atk = 0;
        else if (_stat == StatType.Def) myUnit.ActiveBonusNeutralizer.Def = 0;
        else if (_stat == StatType.Res) myUnit.ActiveBonusNeutralizer.Res = 0;
        else if (_stat == StatType.Spd) myUnit.ActiveBonusNeutralizer.Spd = 0;
    }
}