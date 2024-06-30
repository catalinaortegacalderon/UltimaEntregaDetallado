using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using Fire_Emblem;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class DragonsWrathSecondEffect : Effect
{
    private const double DragonsWrathSecondEffectMultiplier = 0.25;
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        var unitsAtk = TotalStatGetter.GetTotal(StatType.Atk, myUnit);
        var rivalsRes = TotalStatGetter.GetTotal(StatType.Res, opponentsUnit);

        var amount = Convert.ToInt32(Math.Truncate((unitsAtk - rivalsRes) * 
                                                   DragonsWrathSecondEffectMultiplier));
        
        myUnit.DamageEffects.ExtraDamageFirstAttack += amount;
    }
}