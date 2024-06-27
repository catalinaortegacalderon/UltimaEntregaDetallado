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
        int damageAfterCombat = CalculateDamageAfterCombat(myUnit, opponentsUnit);
        AddDamageAfterCombat(opponentsUnit, damageAfterCombat);
    }

    private static int CalculateDamageAfterCombat(Unit myUnit, Unit opponentsUnit)
    {
        int rivalsAttack = TotalStatGetter.GetTotal(StatType.Atk, opponentsUnit);
        int myTotalSpd = TotalStatGetter.GetTotal(StatType.Spd, myUnit);
        int opponentsTotalSpd = TotalStatGetter.GetTotal(StatType.Spd, opponentsUnit);

        bool myUnitHasWeaponAdvantage = DamageCalculator.HasAttackerAdvantage(myUnit.WeaponType, opponentsUnit.WeaponType);

        double damageMultiplier = myTotalSpd > opponentsTotalSpd || myUnitHasWeaponAdvantage 
            ? FirstCasePercentage 
            : SecondCasePercentage;

        return (int)(rivalsAttack * damageMultiplier);
    }

    private static void AddDamageAfterCombat(Unit opponentsUnit, int amount)
    {
        opponentsUnit.CombatEffects.DamageBeforeCombat += amount;
    }
}