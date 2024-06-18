using System.Runtime.CompilerServices;
using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;

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

        double initialDamage = calculator.CalculateAttackForDivineRecreation();
        var finalDamage = calculator.CalculateAttack();

        var amount = (int)((initialDamage - finalDamage) * _percentage);

        if (myUnit.StartedTheRound)
            myUnit.DamageEffects.ExtraDamageFollowup += amount;
        else
            myUnit.DamageEffects.ExtraDamageFirstAttack += amount;
    }
}