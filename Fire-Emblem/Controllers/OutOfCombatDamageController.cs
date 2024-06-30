using ConsoleApp1.GameDataStructures;
using Fire_Emblem_View;

namespace Fire_Emblem.Controllers;

public class OutOfCombatDamageController
{
    private const int MinimumHp = 1;
    private readonly IView _view;

    public OutOfCombatDamageController(IView view)
    {
        _view = view;
    }

    public void ManageHpRecuperationInEveryAttack(Unit attackingUnit, int attackValue)
    {
        if (UnitRecuperatesHp(attackingUnit))
        {
            var amountOfHpRecuperated = CalculateAmountOfHpRecuperated(attackingUnit, attackValue);
            ApplyRecuperatedHp(attackingUnit, amountOfHpRecuperated);
            AnnounceHpRecuperation(attackingUnit, amountOfHpRecuperated);
        }
    }

    private static bool UnitRecuperatesHp(Unit attackingUnit)
    {
        return attackingUnit.CombatEffects.HpRecuperationAtEveryAttack > 0;
    }

    private static int CalculateAmountOfHpRecuperated(Unit attackingUnit, int attackValue)
    {
        return (int)(attackingUnit.CombatEffects.HpRecuperationAtEveryAttack * attackValue);
    }

    private static void ApplyRecuperatedHp(Unit attackingUnit, int amountOfHpRecuperated)
    {
        int finalAmountOfHpRecuperated = amountOfHpRecuperated;
        
        if (DoesHpRecuperationExceedMaximum(attackingUnit, amountOfHpRecuperated))
        {
            finalAmountOfHpRecuperated = attackingUnit.MaxHp - attackingUnit.Hp;
        }

        attackingUnit.Hp += finalAmountOfHpRecuperated;
    }

    private static bool DoesHpRecuperationExceedMaximum(Unit attackingUnit, int amountOfHpRecuperated)
    {
        return attackingUnit.Hp + amountOfHpRecuperated > attackingUnit.MaxHp;
    }

    private void AnnounceHpRecuperation(Unit attackingUnit, int amountOfHpRecuperated)
    {
        if (amountOfHpRecuperated > 0)
        {
            _view.AnnounceHpRecuperation(attackingUnit, amountOfHpRecuperated, attackingUnit.Hp);
        }
    }

    public void ManageDamageAtTheBeginningOfCombat(Unit firstUnit, Unit secondUnit)
    {
        ApplyDamageAtTheBeginningOfCombat(firstUnit);
        ApplyDamageAtTheBeginningOfCombat(secondUnit);
    }

    private void ApplyDamageAtTheBeginningOfCombat(Unit unit)
    {
        if (unit.CombatEffects.DamageBeforeCombat <= 0) return;

        unit.Hp = unit.Hp <= unit.CombatEffects.DamageBeforeCombat ? MinimumHp 
            : unit.Hp - unit.CombatEffects.DamageBeforeCombat;
        _view.AnnounceDamageBeforeCombat(unit, unit.CombatEffects.DamageBeforeCombat);
    }

    public void ManageHpChangeAtTheEndOfCombat(Unit firstUnit, Unit secondUnit)
    {
        ApplyCurationOrDamageAtTheEndOfCombat(firstUnit);
        ApplyCurationOrDamageAtTheEndOfCombat(secondUnit);
    }

    private void ApplyCurationOrDamageAtTheEndOfCombat(Unit unit)
    {
        if (unit.Hp <= 0) return;
        var totalHpChange = CalculateTotalHpChange(unit);
        ApplyHpChange(unit, totalHpChange);
    }
    
    private static int CalculateTotalHpChange(Unit unit)
    {
        if (unit.HasAttackedThisRound)
        {
            unit.CombatEffects.DamageAfterCombat += unit.CombatEffects.DamageAfterCombatIfUnitAttacks;
        }

        int totalHpChange = unit.CombatEffects.HpRecuperationAtTheEndOfTheCombat - unit.CombatEffects.DamageAfterCombat;
        return totalHpChange;
    }

    private void ApplyHpChange(Unit unit, int totalHpChange)
    {
        if (totalHpChange > 0)
        {
            ApplyCuration(unit, totalHpChange);
        }
        else if (totalHpChange < 0)
        {
            ApplyDamage(unit, totalHpChange);
        }
    }

    private void ApplyDamage(Unit unit, int totalDamage)
    {
        unit.Hp = unit.Hp <= -totalDamage ? MinimumHp : unit.Hp + totalDamage;
        _view.AnnounceDamageAfterCombat(unit, -totalDamage);
    }

    private void ApplyCuration(Unit unit, int totalCuration)
    {
        unit.Hp = unit.Hp + totalCuration > unit.MaxHp ? unit.MaxHp : unit.Hp + totalCuration;
        _view.AnnounceCurationAfterCombat(unit, totalCuration);
    }
}
