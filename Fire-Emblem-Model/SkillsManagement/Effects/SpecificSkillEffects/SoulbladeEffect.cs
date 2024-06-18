using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class SoulbladeEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
        // todo: funcionnnn
    {
        double refDesAverage = (opponentsUnit.Def + opponentsUnit.Res) / 2;
        var refDesAverageInt = Convert.ToInt32(Math.Truncate(refDesAverage));
        var defChange = refDesAverageInt - opponentsUnit.Def;
        var resChange = refDesAverageInt - opponentsUnit.Res;
        if (defChange < 0) opponentsUnit.ActivePenalties.Def += defChange;
        else
            opponentsUnit.ActiveBonus.Def += defChange;
        if (resChange < 0) opponentsUnit.ActivePenalties.Res += resChange;
        else
            opponentsUnit.ActiveBonus.Res += resChange;
    }
}