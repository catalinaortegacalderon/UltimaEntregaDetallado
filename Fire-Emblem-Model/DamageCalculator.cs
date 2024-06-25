using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem;

namespace ConsoleApp1;

public class DamageCalculator
{
    private const double WtbValueForNoAdvantage = 1;
    private const double WtbValueForAttackersAdvantage = 1.2;
    private const double WtbValueForDefensorsAdvantage = 0.8;
    private readonly Unit _currentAttackingUnit;
    private readonly Unit _currentDefensiveUnit;
    private readonly AttackType _typeOfThisRoundsCurrentAttack;

    public DamageCalculator(Unit attackingUnit, Unit defensiveUnit, AttackType attackType)
    {
        _currentAttackingUnit = attackingUnit;
        _currentDefensiveUnit = defensiveUnit;
        _typeOfThisRoundsCurrentAttack = attackType;
    }

    public int CalculateAttack()
    {
        var initialDamage = CalculateInitialDamage();
        double finalDamage = CalculateFinalDamage(initialDamage);
        finalDamage = Convert.ToInt32(Math.Floor(finalDamage));

        if (finalDamage < 0)
            return 0;
        return Convert.ToInt32(Math.Truncate(finalDamage));
    }

    public int CalculateAttackForDivineRecreation()
    {
        var initialDamage = CalculateInitialDamage();
        double finalDamage = CalculateFinalDamageForDivineRecreation(initialDamage);
        if (finalDamage < 0)
            return 0;
        return Convert.ToInt32(Math.Truncate(finalDamage));
    }

    private int CalculateInitialDamage()
    {
        var rivalsDefOrRes = CalculateOpponentsDefOrRes();
        var wtb = CalculateWtb();
        var unitsAtk = CalculateUnitsAtk();

        var initialDamage = Convert.ToInt32(Math.Floor(unitsAtk * wtb - rivalsDefOrRes));
        if (initialDamage < 0)
            initialDamage = 0;

        return initialDamage;
    }

// todo: codigo duplicado unidad y oponente
    private int CalculateUnitsAtk()
    {
        var unitsAtk = TotalStatGetter.GetTotal(StatType.Atk, _currentAttackingUnit);

        if (IsFirstOrSecondAttack())
            unitsAtk += TotalStatGetter.GetFirstAttackStat(StatType.Atk, _currentAttackingUnit);
        if (IsFollowUp())
            unitsAtk += TotalStatGetter.GetFollowUpStat(StatType.Atk, _currentAttackingUnit);
        return unitsAtk;
    }

    private bool IsFollowUp()
    {
        return _typeOfThisRoundsCurrentAttack == AttackType.FollowUp;
    }

    private bool IsFirstOrSecondAttack()
    {
        return _typeOfThisRoundsCurrentAttack is AttackType.FirstAttack or AttackType.SecondAttack;
    }

    private double CalculateWtb()
    {
        double wtb;
        if (IsNoAdvantage(_currentAttackingUnit.WeaponType, _currentDefensiveUnit.WeaponType))
            wtb = WtbValueForNoAdvantage;
        else if (DoesAttackerHaveAdvantage(_currentAttackingUnit.WeaponType, _currentDefensiveUnit.WeaponType))
            wtb = WtbValueForAttackersAdvantage;
        else
            wtb = WtbValueForDefensorsAdvantage;
        return wtb;
    }

    private int CalculateOpponentsDefOrRes()
    {
        // todo: seguir arreglando con total stat getter
        var attackingWeapon = _currentAttackingUnit.WeaponType;

        int rivalsDefOrRes;
        if (attackingWeapon == WeaponType.Magic)
        {
            rivalsDefOrRes = TotalStatGetter.GetTotal(StatType.Res, _currentDefensiveUnit);
            if (IsFirstOrSecondAttack())
                rivalsDefOrRes += TotalStatGetter.GetFirstAttackStat(StatType.Res, _currentDefensiveUnit);
        }
        else
        {
            rivalsDefOrRes = TotalStatGetter.GetTotal(StatType.Def, _currentDefensiveUnit);

            if (IsFirstOrSecondAttack())
                rivalsDefOrRes += TotalStatGetter.GetFirstAttackStat(StatType.Def, _currentDefensiveUnit);
        }

        return rivalsDefOrRes;
    }

    private int CalculateFinalDamage(double initialDamage)
    {
        var finalDamage = initialDamage;
        // todo: separar en funciones
        if (IsFirstOrSecondAttack())
            finalDamage =
                (initialDamage + _currentAttackingUnit.DamageEffects.ExtraDamage
                               + _currentAttackingUnit.DamageEffects.ExtraDamageFirstAttack)
                * _currentDefensiveUnit.DamageEffects.PercentageReduction
                * _currentDefensiveUnit.DamageEffects.PercentageReductionOpponentsFirstAttack
                + _currentDefensiveUnit.DamageEffects.AbsolutDamageReduction;
        else if (IsFollowUp())
            finalDamage =
                (initialDamage + _currentAttackingUnit.DamageEffects.ExtraDamage
                               + _currentAttackingUnit.DamageEffects.ExtraDamageFollowup)
                * _currentDefensiveUnit.DamageEffects.PercentageReduction
                * _currentDefensiveUnit.DamageEffects.PercentageReductionOpponentsFollowup
                + _currentDefensiveUnit.DamageEffects.AbsolutDamageReduction;
        var newDamage = Math.Round(finalDamage, 9);
        var damage = Convert.ToInt32(Math.Floor(newDamage));
        return damage;
    }

    private int CalculateFinalDamageForDivineRecreation(double initialDamage)
    {
        var finalDamage = initialDamage;
        if (IsFirstOrSecondAttack())
            finalDamage =
                initialDamage + _currentAttackingUnit.DamageEffects.ExtraDamage +
                _currentAttackingUnit.DamageEffects.ExtraDamageFirstAttack;
        else if (IsFollowUp())
            finalDamage =
                initialDamage + _currentAttackingUnit.DamageEffects.ExtraDamage +
                _currentAttackingUnit.DamageEffects.ExtraDamageFollowup;
        // todo: sacar espacios
        var newDamage = Math.Round(finalDamage, 9);
        var damage = Convert.ToInt32(Math.Floor(newDamage));
        return damage;
    }

    public static bool DoesAttackerHaveAdvantage(WeaponType attackingWeaponType, WeaponType defensiveWeaponType)
    {
        return (attackingWeaponType == WeaponType.Sword) & (defensiveWeaponType == WeaponType.Axe) ||
               (attackingWeaponType == WeaponType.Lance) & (defensiveWeaponType == WeaponType.Sword) ||
               (attackingWeaponType == WeaponType.Axe) & (defensiveWeaponType == WeaponType.Lance);
    }

    public static bool IsNoAdvantage(WeaponType attackingWeaponType, WeaponType defensiveWeaponType)
    {
        return defensiveWeaponType == attackingWeaponType
               || attackingWeaponType == WeaponType.Magic
               || defensiveWeaponType == WeaponType.Magic
               || defensiveWeaponType == WeaponType.Bow
               || attackingWeaponType == WeaponType.Bow;
    }
}