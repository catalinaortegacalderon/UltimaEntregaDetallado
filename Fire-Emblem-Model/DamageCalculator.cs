using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1;

public class DamageCalculator
{
    private const double NoAdvantageMultiplier = 1;
    private const double AttackerAdvantageMultiplier = 1.2;
    private const double DefenderAdvantageMultiplier = 0.8;

    private readonly Unit _attackingUnit;
    private readonly Unit _defensiveUnit;
    private readonly AttackType _currentAttackType;

    public DamageCalculator(Unit attackingUnit, Unit defensiveUnit, AttackType attackType)
    {
        _attackingUnit = attackingUnit;
        _defensiveUnit = defensiveUnit;
        _currentAttackType = attackType;
    }

    public int CalculateAttack()
    {
        int initialDamage = CalculateInitialDamage();
        double finalDamage = CalculateFinalDamage(initialDamage);
        return Math.Max(0, (int)Math.Truncate(finalDamage));
    }

    public int CalculateAttackForDivineRecreationOrBrashAssault()
    {
        int initialDamage = CalculateInitialDamage();
        double finalDamage = CalculateFinalDamageForDivineRecreationOrBrashAssault(initialDamage);
        return Math.Max(0, (int)Math.Truncate(finalDamage));
    }

    private int CalculateInitialDamage()
    {
        int defenseOrResistance = GetDefensiveStat();
        double weaponTriangleBonus = GetWeaponTriangleBonus();
        int attackPower = GetAttackPower();

        var initialDamage = attackPower * weaponTriangleBonus - defenseOrResistance;
        
        return Math.Max(0, (int)Math.Floor(initialDamage));
    }

    private int GetAttackPower()
    {
        int attackPower = TotalStatGetter.GetTotal(StatType.Atk, _attackingUnit);

        if (IsFirstOrSecondAttack())
            attackPower += TotalStatGetter.GetFirstAttackStat(StatType.Atk, _attackingUnit);
        if (IsFollowUp())
            attackPower += TotalStatGetter.GetFollowUpStat(StatType.Atk, _attackingUnit);

        return attackPower;
    }

    private bool IsFollowUp() 
        => _currentAttackType == AttackType.FollowUp;

    private bool IsFirstOrSecondAttack() 
        => _currentAttackType is AttackType.FirstAttack or AttackType.SecondAttack;

    private double GetWeaponTriangleBonus()
    {
        if (IsNoAdvantage(_attackingUnit.WeaponType, _defensiveUnit.WeaponType))
            return NoAdvantageMultiplier;
        if (HasAttackerAdvantage(_attackingUnit.WeaponType, _defensiveUnit.WeaponType))
            return AttackerAdvantageMultiplier;
        
        return DefenderAdvantageMultiplier;
    }

    private int GetDefensiveStat()
    {
        WeaponType attackingWeapon = _attackingUnit.WeaponType;
        
        int defensiveStat = attackingWeapon == WeaponType.Magic
            ? TotalStatGetter.GetTotal(StatType.Res, _defensiveUnit)
            : TotalStatGetter.GetTotal(StatType.Def, _defensiveUnit);

        if (IsFirstOrSecondAttack())
        {
            defensiveStat += attackingWeapon == WeaponType.Magic
                ? TotalStatGetter.GetFirstAttackStat(StatType.Res, _defensiveUnit)
                : TotalStatGetter.GetFirstAttackStat(StatType.Def, _defensiveUnit);
        }

        return defensiveStat;
    }

    private double CalculateFinalDamage(double initialDamage)
    {
        double finalDamage = initialDamage;

        if (IsFirstOrSecondAttack())
            finalDamage = CalculateFinalDamageForFirstOrSecondAttack(initialDamage);
        else if (IsFollowUp())
            finalDamage = CalculateFinalDamageForFollowUp(initialDamage);

        return Math.Round(finalDamage, 9);
    }

    private double CalculateFinalDamageForFirstOrSecondAttack(double initialDamage)
    {
        return (initialDamage + _attackingUnit.DamageEffects.ExtraDamage 
                              + _attackingUnit.DamageEffects.ExtraDamageFirstAttack)
               * _defensiveUnit.DamageEffects.PercentageReduction
               * _defensiveUnit.DamageEffects.PercentageReductionOpponentsFirstAttack
               + _defensiveUnit.DamageEffects.AbsoluteDamageReduction;
    }

    private double CalculateFinalDamageForFollowUp(double initialDamage)
    {
        return (initialDamage + _attackingUnit.DamageEffects.ExtraDamage 
                              + _attackingUnit.DamageEffects.ExtraDamageFollowup)
               * _defensiveUnit.DamageEffects.PercentageReduction
               * _defensiveUnit.DamageEffects.PercentageReductionOpponentsFollowup
               + _defensiveUnit.DamageEffects.AbsoluteDamageReduction;
    }

    private double CalculateFinalDamageForDivineRecreationOrBrashAssault(double initialDamage)
    {
        double finalDamage = initialDamage;

        if (IsFirstOrSecondAttack())
            finalDamage += _attackingUnit.DamageEffects.ExtraDamage 
                           + _attackingUnit.DamageEffects.ExtraDamageFirstAttack;
        else if (IsFollowUp())
            finalDamage += _attackingUnit.DamageEffects.ExtraDamage 
                           + _attackingUnit.DamageEffects.ExtraDamageFollowup;

        return Math.Round(finalDamage, 9);
    }

    public static bool HasAttackerAdvantage(WeaponType attackerWeapon, WeaponType defenderWeapon)
    {
        return (attackerWeapon == WeaponType.Sword && defenderWeapon == WeaponType.Axe) ||
               (attackerWeapon == WeaponType.Lance && defenderWeapon == WeaponType.Sword) ||
               (attackerWeapon == WeaponType.Axe && defenderWeapon == WeaponType.Lance);
    }

    public static bool IsNoAdvantage(WeaponType attackerWeapon, WeaponType defenderWeapon)
    {
        return attackerWeapon == defenderWeapon ||
               attackerWeapon == WeaponType.Magic || defenderWeapon == WeaponType.Magic ||
               attackerWeapon == WeaponType.Bow || defenderWeapon == WeaponType.Bow;
    }
}
