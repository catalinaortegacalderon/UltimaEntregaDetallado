using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.NeutralizationEffects;

public class NeutralizeOpponentsBonusEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        opponentsUnit.ActiveBonusNeutralizer.Atk = 0;
        opponentsUnit.ActiveBonusNeutralizer.AtkFollowup = 0;
        opponentsUnit.ActiveBonusNeutralizer.AtkFirstAttack = 0;
        opponentsUnit.ActiveBonusNeutralizer.Spd = 0;
        opponentsUnit.ActiveBonusNeutralizer.Def = 0;
        opponentsUnit.ActiveBonusNeutralizer.Res = 0;
    }
}