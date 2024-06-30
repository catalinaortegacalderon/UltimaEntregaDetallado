using System.Runtime.CompilerServices;
using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class BrashAssaultEffect : Effect
{
    private readonly double _percentage;
    public BrashAssaultEffect(double percentage)
    {
        _percentage = percentage;
    }
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        var amount = CalculateExtraDamage(myUnit, opponentsUnit);
        ApplyExtraDamage(myUnit, amount);
    }

    private static void ApplyExtraDamage(Unit myUnit, int amount)
    {
        if (myUnit.StartedTheRound)
            myUnit.DamageEffects.ExtraDamageFollowup += amount;
        else
            myUnit.DamageEffects.ExtraDamageFirstAttack += amount;
    }

    private int CalculateExtraDamage(Unit myUnit, Unit opponentsUnit)
    {
        var calculator = new DamageCalculator(opponentsUnit, myUnit,
            AttackType.FirstAttack);

        double initialDamage = calculator.CalculateAttackForDivineRecreationOrBrashAssault();

        var amount = (int)((initialDamage) * _percentage);
        return amount;
    }
}