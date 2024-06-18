using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class DragonsWrathSecondEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        var unitsAtk = myUnit.Atk + myUnit.ActiveBonus.Atk
            * myUnit.ActiveBonusNeutralizer.Atk + myUnit.ActivePenalties.Atk
            * myUnit.ActivePenaltiesNeutralizer.Atk;

        var rivalsRes = opponentsUnit.Res + opponentsUnit.ActiveBonus.Res
            * opponentsUnit.ActiveBonusNeutralizer.Res + opponentsUnit.ActivePenalties.Res
            * opponentsUnit.ActivePenaltiesNeutralizer.Res;

        var amount = Convert.ToInt32(Math.Truncate((unitsAtk - rivalsRes) * 0.25));
        myUnit.DamageEffects.ExtraDamageFirstAttack += amount;
    }
}