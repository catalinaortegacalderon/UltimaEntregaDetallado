using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.NeutralizationEffects;

public class NeutralizePenaltiesEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        myUnit.ActivePenaltiesNeutralizer.Atk = 0;
        myUnit.ActivePenaltiesNeutralizer.Spd = 0;
        myUnit.ActivePenaltiesNeutralizer.Def = 0;
        myUnit.ActivePenaltiesNeutralizer.Res = 0;
    }
}