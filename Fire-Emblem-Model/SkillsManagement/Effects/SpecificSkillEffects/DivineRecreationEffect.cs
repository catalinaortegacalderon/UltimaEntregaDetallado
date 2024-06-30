using System.Runtime.CompilerServices;
using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class DivineRecreationEffect : Effect
{
    private double _percentage;
    public DivineRecreationEffect(double percentage)
    {
        _percentage = percentage;
    }
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        var calculator = new DamageCalculator(opponentsUnit, myUnit,
            AttackType.FirstAttack);

        double initialDamage = calculator.CalculateAttackForDivineRecreationOrBrashAssault();
        var finalDamage = calculator.CalculateAttack();

        var amount = (int)((initialDamage - finalDamage) * _percentage);

        if (myUnit.StartedTheRound)
            myUnit.DamageEffects.ExtraDamageFollowup += amount;
        else
            myUnit.DamageEffects.ExtraDamageFirstAttack += amount;
        
        Console.WriteLine(amount);
    }
}