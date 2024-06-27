using ConsoleApp1.GameDataStructures;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class OutOfCombatDamageController(IView view)
{
    
    // todo: ordenar esta clase

    public void ManaManageHpRecuperationInEveryAttack(Unit attackingUnit, int attackValue)
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
        return (int)(attackingUnit.CombatEffects.HpRecuperationAtEveryAttack 
                     * attackValue);
    }
    
    private static void ApplyRecuperatedHp(Unit attackingUnit, int amountOfHpRecuperated)
    {
        var finalAmountOfHpRecuperated = amountOfHpRecuperated;
        
        if (DoesHpRecuperationExceedMaximum(attackingUnit, amountOfHpRecuperated))
            finalAmountOfHpRecuperated = attackingUnit.MaxHp - attackingUnit.Hp;
        
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
            view.AnnounceHpRecuperation(attackingUnit, amountOfHpRecuperated , 
                attackingUnit.Hp);
        }
    }

    public void ManageDamageAtTheBeginningOfTheCombat(
        Unit firstUnitToProcess, Unit secondUnitToProcess)
    { 
        ApplyDamageAtTheBeginningOfTheCombat(firstUnitToProcess);
        ApplyDamageAtTheBeginningOfTheCombat(secondUnitToProcess);
        
    }

    private void ApplyDamageAtTheBeginningOfTheCombat(Unit unit)
    {
        if (unit.CombatEffects.DamageBeforeCombat > 0 )
        {
            if (unit.Hp <= unit.CombatEffects.DamageBeforeCombat)
            {
                unit.Hp = 1;
            }
            else
            {
                unit.Hp -= unit.CombatEffects.DamageBeforeCombat;
            }
            view.AnnounceDamageBeforeCombat(unit, 
                unit.CombatEffects.DamageBeforeCombat);
        }
    }

    public void ManageHpChangeAtTheEndOfTheCombat(Unit firstUnitToProcess, Unit secondUnitToProcess)
    {
        ManageCurationAndDamageAtTheEndOfTheCombat(firstUnitToProcess, secondUnitToProcess);
    }
    
    private void ManageCurationAndDamageAtTheEndOfTheCombat(Unit firstUnitToProcess, Unit secondUnitToProcess)
    { 
        ApplyCurationOrDamageAtTheEndOfTheCombat(firstUnitToProcess);
        ApplyCurationOrDamageAtTheEndOfTheCombat(secondUnitToProcess);
    }

    private void ApplyCurationOrDamageAtTheEndOfTheCombat(Unit unit)
    {
        // todo: poner mas bonito
        
        if (unit.HasAttackedThisRound)
            unit.CombatEffects.DamageAfterCombat
                += unit.CombatEffects.DamageAfterCombatIfUnitAttacks;
        
        var totalDamageOrCuration = unit.CombatEffects.HpRecuperationAtTheEndOfTheCombat
                                    - unit.CombatEffects.DamageAfterCombat;
        
        if (totalDamageOrCuration > 0 && unit.Hp > 0)
            ApplyCuration(unit, totalDamageOrCuration);
        if (totalDamageOrCuration < 0 && unit.Hp > 0) 
            ApplyDamage(unit, totalDamageOrCuration);
    }

    private void ApplyDamage(Unit unit, int totalDamageOrCuration)
    {
        if (unit.Hp <= -totalDamageOrCuration)
        {
            unit.Hp = 1;
        }
        else
        {
            unit.Hp += totalDamageOrCuration;
        }

        view.AnnounceDamageAfterCombat(unit, 
            -totalDamageOrCuration);
    }

    private void ApplyCuration(Unit unit, int totalDamageOrCuration)
    {
        if (unit.Hp + totalDamageOrCuration > unit.MaxHp)
            unit.Hp = unit.MaxHp;
        else
        {
            unit.Hp += totalDamageOrCuration;
        }

        view.AnnounceCurationAfterCombat(unit, 
            totalDamageOrCuration);
    }
}