using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class BewitchingTomeEffect : Effect
{
    private const double FirstCasePercentage = 0.4;
    private const double SecondCasePercentage = 0.2;

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        var damageAfterCombat = CalculateDamageAfterCombat(myUnit, opponentsUnit);
        AddDamageAfterCombat(opponentsUnit, damageAfterCombat);
    }

    private static int CalculateDamageAfterCombat(Unit myUnit, Unit opponentsUnit)
    {
        var rivalsAttack = TotalStatGetter.GetTotal(StatType.Atk, opponentsUnit);
        var myTotalSpd = TotalStatGetter.GetTotal(StatType.Spd, myUnit);
        var opponentsTotalSpd = TotalStatGetter.GetTotal(StatType.Spd, opponentsUnit);

        var myUnitHasWeaponAdvantage = DamageCalculator.HasAttackerAdvantage(myUnit.WeaponType, opponentsUnit.WeaponType);

        var damageMultiplier = myTotalSpd > opponentsTotalSpd || myUnitHasWeaponAdvantage 
            ? FirstCasePercentage 
            : SecondCasePercentage;

        return (int)(rivalsAttack * damageMultiplier);
    }

    private static void AddDamageAfterCombat(Unit opponentsUnit, int amount)
    {
        opponentsUnit.CombatEffects.DamageBeforeCombat += amount;
    }
}