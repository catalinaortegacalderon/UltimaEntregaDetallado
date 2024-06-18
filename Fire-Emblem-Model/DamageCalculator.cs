using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;

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
        var unitsAtk = _currentAttackingUnit.Atk + _currentAttackingUnit.ActiveBonus.Atk
                                                 * _currentAttackingUnit.ActiveBonusNeutralizer.Atk
                                                 + _currentAttackingUnit.ActivePenalties.Atk
                                                 * _currentAttackingUnit.ActivePenaltiesNeutralizer.Atk;

        if (IsFirstOrSecondAttack())
            unitsAtk += _currentAttackingUnit.ActiveBonus.AtkFirstAttack
                        * _currentAttackingUnit.ActiveBonusNeutralizer.Atk
                        + _currentAttackingUnit.ActivePenalties.AtkFirstAttack
                        * _currentAttackingUnit.ActivePenaltiesNeutralizer.Atk;
        if (IsFollowUp())
            unitsAtk += _currentAttackingUnit.ActiveBonus.AtkFollowup
                        * _currentAttackingUnit.ActiveBonusNeutralizer.Atk
                        + _currentAttackingUnit.ActivePenalties.AtkFollowup
                        * _currentAttackingUnit.ActivePenaltiesNeutralizer.Atk;
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
        if (IsNoAdvantage(_currentAttackingUnit.Weapon, _currentDefensiveUnit.Weapon))
            wtb = WtbValueForNoAdvantage;
        else if (DoesAttackerHaveAdvantage(_currentAttackingUnit.Weapon, _currentDefensiveUnit.Weapon))
            wtb = WtbValueForAttackersAdvantage;
        else
            wtb = WtbValueForDefensorsAdvantage;
        return wtb;
    }

    private int CalculateOpponentsDefOrRes()
    {
        var attackingWeapon = _currentAttackingUnit.Weapon;

        int rivalsDefOrRes;
        if (attackingWeapon == Weapon.Magic)
        {
            rivalsDefOrRes = _currentDefensiveUnit.Res + _currentDefensiveUnit.ActiveBonus.Res
                                                       * _currentDefensiveUnit.ActiveBonusNeutralizer.Res
                                                       + _currentDefensiveUnit.ActivePenalties.Res
                                                       * _currentDefensiveUnit.ActivePenaltiesNeutralizer.Res;

            if (IsFirstOrSecondAttack())
                rivalsDefOrRes += _currentDefensiveUnit.ActiveBonus.ResFirstAttack
                                  * _currentDefensiveUnit.ActiveBonusNeutralizer.Res
                                  + _currentDefensiveUnit.ActivePenalties.ResFirstAttack
                                  * _currentDefensiveUnit.ActivePenaltiesNeutralizer.Res;
        }
        else
        {
            rivalsDefOrRes = _currentDefensiveUnit.Def + _currentDefensiveUnit.ActiveBonus.Def
                                                       * _currentDefensiveUnit.ActiveBonusNeutralizer.Def
                                                       + _currentDefensiveUnit.ActivePenalties.Def
                                                       * _currentDefensiveUnit.ActivePenaltiesNeutralizer.Def;

            if (IsFirstOrSecondAttack())
                rivalsDefOrRes += _currentDefensiveUnit.ActiveBonus.DefFirstAttack
                                  * _currentDefensiveUnit.ActiveBonusNeutralizer.Def
                                  + _currentDefensiveUnit.ActivePenalties.DefFirstAttack
                                  * _currentDefensiveUnit.ActivePenaltiesNeutralizer.Def;
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

    public static bool DoesAttackerHaveAdvantage(Weapon attackingWeapon, Weapon defensiveWeapon)
    {
        return (attackingWeapon == Weapon.Sword) & (defensiveWeapon == Weapon.Axe) ||
               (attackingWeapon == Weapon.Lance) & (defensiveWeapon == Weapon.Sword) ||
               (attackingWeapon == Weapon.Axe) & (defensiveWeapon == Weapon.Lance);
    }

    public static bool IsNoAdvantage(Weapon attackingWeapon, Weapon defensiveWeapon)
    {
        return defensiveWeapon == attackingWeapon
               || attackingWeapon == Weapon.Magic
               || defensiveWeapon == Weapon.Magic
               || defensiveWeapon == Weapon.Bow
               || attackingWeapon == Weapon.Bow;
    }
}