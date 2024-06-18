using ConsoleApp1.GameDataStructures;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class OutOfCombatDamageManager
{
    
    // todo: ordenar esta clase
    private readonly GameView _view;
    public OutOfCombatDamageManager(GameView view)
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
            if (attackingUnit.CurrentHp + amountOfHpRecuperated > attackingUnit.HpMax)
            {
                finalAmountOfHpRecuperated = attackingUnit.HpMax - attackingUnit.CurrentHp;
            }
            attackingUnit.CurrentHp += finalAmountOfHpRecuperated;
            if (amountOfHpRecuperated > 0)
            {
                _view.AnnounceHpRecuperation(attackingUnit, amountOfHpRecuperated , 
                    attackingUnit.CurrentHp);
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
            if (unit.CurrentHp <= unit.CombatEffects.DamageBeforeCombat)
            {
                unit.CurrentHp = 1;
            }
            else
            {
                unit.CurrentHp -= unit.CombatEffects.DamageBeforeCombat;
            }
            _view.AnnounceDamageBeforeCombat(unit, 
                unit.CombatEffects.DamageBeforeCombat);
        }
    }

    public void ManageHpChangeAtTheEndOfTheCombat(Unit firstUnitToProcess, Unit secondUnitToProcess)
    {
        ManageCurationAtTheEndOfTheCombat(firstUnitToProcess, secondUnitToProcess);
        ManageDamageAtTheEndOfTheCombat(firstUnitToProcess, secondUnitToProcess);
    }
    
    private void ManageCurationAtTheEndOfTheCombat(Unit firstUnitToProcess, Unit secondUnitToProcess)
    { 
        ApplyCurationAtTheEndOfTheCombat(firstUnitToProcess);
        ApplyCurationAtTheEndOfTheCombat(secondUnitToProcess);
    }

    private void ApplyCurationAtTheEndOfTheCombat(Unit unit)
    {
        if (unit.CombatEffects.HpRecuperationAtTheEndOfTheCombat > 0 
            && unit.CurrentHp > 0)
        { 
            if (unit.CurrentHp + unit.CombatEffects.HpRecuperationAtTheEndOfTheCombat
                > unit.HpMax)
                unit.CurrentHp = unit.HpMax;
            else
            {
                unit.CurrentHp += unit.CombatEffects.HpRecuperationAtTheEndOfTheCombat;
            }
            _view.AnnounceCurationAfterCombat(unit, 
                unit.CombatEffects.HpRecuperationAtTheEndOfTheCombat);
        }
    }


    private void ManageDamageAtTheEndOfTheCombat(Unit firstUnitToProcess, Unit secondUnitToProcess)
    { 
        ApplyDamageAfterCombat(firstUnitToProcess);
        ApplyDamageAfterCombat(secondUnitToProcess);
    }

    private void ApplyDamageAfterCombat(Unit unit)
    {
        if (unit.HasAttackedThisRound)
            unit.CombatEffects.DamageAfterCombat
                += unit.CombatEffects.DamageAfterCombatIfUnitAttacks;
        
        if (unit.CombatEffects.DamageAfterCombat > 0 && unit.CurrentHp > 0)
        {
            if (unit.CurrentHp <= unit.CombatEffects.DamageAfterCombat)
            {
                unit.CurrentHp = 1;
            }
            else
            {
                unit.CurrentHp -= unit.CombatEffects.DamageAfterCombat;
            }
            _view.AnnounceDamageAfterCombat(unit, 
                unit.CombatEffects.DamageAfterCombat);
        }
    }
}