using ConsoleApp1.GameDataStructures;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class OutOfCombatDamageController
{
    
    // todo: ordenar esta clase
    private readonly IView _view;
    public OutOfCombatDamageController(IView view)
    {
        _view = view;
    }

    public void ManaManageHpRecuperationInEveryAttack(Unit attackingUnit, Unit defensiveUnit,
        int attackValue)
    {
        // todo: esta funcion separarla en, calculate recuperation, apply, anounce
        if (attackingUnit.CombatEffects.HpRecuperationAtEveryAttack > 0)
        {
            var amountOfHpRecuperated = (int)(attackingUnit.CombatEffects.HpRecuperationAtEveryAttack 
                                              * attackValue);
            int finalAmountOfHpRecuperated = amountOfHpRecuperated;
            if (attackingUnit.Hp + amountOfHpRecuperated > attackingUnit.MaxHp)
            {
                finalAmountOfHpRecuperated = attackingUnit.MaxHp - attackingUnit.Hp;
            }
            attackingUnit.Hp += finalAmountOfHpRecuperated;
            if (amountOfHpRecuperated > 0)
            {
                _view.AnnounceHpRecuperation(attackingUnit, amountOfHpRecuperated , 
                    attackingUnit.Hp);
            }
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
            _view.AnnounceDamageBeforeCombat(unit, 
                unit.CombatEffects.DamageBeforeCombat);
        }
    }

    public void ManageHpChangeAtTheEndOfTheCombat(Unit firstUnitToProcess, Unit secondUnitToProcess)
    {
        ManageCurationAndDamageAtTheEndOfTheCombat(firstUnitToProcess, secondUnitToProcess);
        //ManageDamageAtTheEndOfTheCombat(firstUnitToProcess, secondUnitToProcess);
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

        _view.AnnounceDamageAfterCombat(unit, 
            -totalDamageOrCuration);
    }

    private void ApplyCuration(Unit unit, int totalDamageOrCuration)
    {
        if (unit.Hp + totalDamageOrCuration
            > unit.MaxHp)
            unit.Hp = unit.MaxHp;
        else
        {
            unit.Hp += totalDamageOrCuration;
        }

        _view.AnnounceCurationAfterCombat(unit, 
            totalDamageOrCuration);
    }
}