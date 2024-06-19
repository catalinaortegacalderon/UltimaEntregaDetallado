using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class FlowEffect : Effect
{
    private readonly StatType _stat;

    public FlowEffect(StatType stat)
    {
        _stat = stat;
    }
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        var myTotalStat = TotalStatGetter.GetTotal(_stat, myUnit);
        var opponentsTotalStat = TotalStatGetter.GetTotal(_stat, opponentsUnit);

        var amount = CalculateAmount(myTotalStat, opponentsTotalStat);

        myUnit.DamageEffects.ExtraDamage += amount; 
        myUnit.DamageEffects.AbsolutDamageReduction -= amount; 
    }

    private static int CalculateAmount(int myTotalStat, int opponentsTotalStat)
    {
        int amount = (int)((myTotalStat - opponentsTotalStat) * 0.7);
        if (amount < 0)
            amount = 0;
        if (amount > 7)
            amount = 7;
        return amount;
    }
}