using ConsoleApp1.DataTypes;
using ConsoleApp1.EncapsulatedLists;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem_GUI;
using Fire_Emblem_View;

namespace Fire_Emblem.Controllers;

public class RoundController
{
    private const int IdOfPlayer1 = 0;
    private const int IdOfPlayer2 = 1;

    private readonly IView _view;
    private int _currentRound;

    private readonly Player _player1;
    private readonly Player _player2;
    private int _currentUnitNumberOfPlayer1;
    private int _currentUnitNumberOfPlayer2;
    private Unit _currentUnitOfPlayer1;
    private Unit _currentUnitOfPlayer2;

    private readonly GameAttacksController _attackController;
    private readonly FollowUpController _followUpController;
    private readonly OutOfCombatDamageController _outOfCombatDamageController;

    public RoundController(IView view, int currentRound, Player player1,
        Player player2, GameAttacksController attackController)
    {
        _view = view;
        _currentRound = currentRound;
        _player1 = player1;
        _player2 = player2;
        _attackController = attackController;
        _followUpController = new FollowUpController(_attackController, _view);
        _outOfCombatDamageController = new OutOfCombatDamageController(_view);
    }

    public void ExecuteRound()
    {
        ResetRound();
        SetCurrentAttacker();
        SetCurrentUnits();
        DisplayRoundInfo();
        CheckAndApplyAllySkills();
        InitializeRoundCombat();
        ManageInitialHpChange();
        ExecuteCombat();
        ManageFollowUp();
        ManageEndHpChange();
        ResetUnitBonuses();
        DisplayRemainingHp();
        LogGameUpdates();
        EliminateDeadUnits();
        IncrementRound();
    }
    
    private void ResetRound()
    {
        _attackController.RestartRound();
    }

    private void SetCurrentAttacker()
    {
        _attackController.SetCurrentAttacker(IsPlayer1StartingRound() ? IdOfPlayer1 : IdOfPlayer2);
    }

    private bool IsPlayer1StartingRound()
    {
        return _currentRound % 2 == 1;
    }

    private void SetCurrentUnits()
    {
        var chosenUnits = _view.AskBothPlayersForTheChosenUnit(_attackController.GetPlayers(),
            _attackController.GetCurrentAttacker());
        
        _currentUnitNumberOfPlayer1 = chosenUnits[IdOfPlayer1];
        _currentUnitNumberOfPlayer2 = chosenUnits[IdOfPlayer2];
        
        _currentUnitOfPlayer1 = _player1.Units.GetUnitByIndex(_currentUnitNumberOfPlayer1);
        _currentUnitOfPlayer2 = _player2.Units.GetUnitByIndex(_currentUnitNumberOfPlayer2);
    }

    private void DisplayRoundInfo()
    {
        var playerNumber = _attackController.GetCurrentAttacker() == IdOfPlayer1 ? 1 : 2;
        _view.ShowRoundInformation(_currentRound, GetCurrentAttackerName(), playerNumber);
    }

    private string GetCurrentAttackerName()
    {
        return IsPlayer1StartingRound() ? _currentUnitOfPlayer1.Name : _currentUnitOfPlayer2.Name;
    }

    private void CheckAndApplyAllySkills()
    {
        ApplyAllySkills(_player1, _currentUnitOfPlayer1);
        ApplyAllySkills(_player2, _currentUnitOfPlayer2);
    }

    private static void ApplyAllySkills(Player player, Unit currentUnit)
    {
        currentUnit.HasAnAllyWithMagic = player.Units.Any(unit =>
            AliveAllyUnitHasMagic(currentUnit, unit));
    }

    private static bool AliveAllyUnitHasMagic(Unit currentUnit, Unit unit)
    {
        return unit.Hp > 0 && unit.WeaponType == WeaponType.Magic && unit != currentUnit;
    }

    private void InitializeRoundCombat()
    {
        var (attacker, defender) = IsPlayer1StartingRound()
            ? (_currentUnitOfPlayer1, _currentUnitOfPlayer2)
            : (_currentUnitOfPlayer2, _currentUnitOfPlayer1);
        _attackController.InitializeRound(attacker, defender);
    }

    private void ManageInitialHpChange()
    {
        var (unit1, unit2) = IsPlayer1StartingRound()
            ? (_currentUnitOfPlayer1, _currentUnitOfPlayer2)
            : (_currentUnitOfPlayer2, _currentUnitOfPlayer1);
        _outOfCombatDamageController.ManageDamageAtTheBeginningOfCombat(unit1, unit2);
    }

    private void ExecuteCombat()
    {
        var (attacker, defender) = IsPlayer1StartingRound()
            ? (_currentUnitOfPlayer1, _currentUnitOfPlayer2)
            : (_currentUnitOfPlayer2, _currentUnitOfPlayer1);
        
        _attackController.GenerateAnAttackBetweenTwoUnits(AttackType.FirstAttack, attacker,
            defender);
        _attackController.ChangeAttacker();
        
        if (CanDefenderCounterAttack(defender))
        {
            _attackController.GenerateAnAttackBetweenTwoUnits(AttackType.SecondAttack, defender,
                attacker);
        }
    }

    private bool CanDefenderCounterAttack(Unit defender)
    {
        return !defender.CombatEffects.HasCounterAttackDenial ||
               defender.CombatEffects.HasNeutralizationOfCounterattackDenial;
    }

    private void ManageFollowUp()
    {
        var (attacker, defender, attackerId) = IsPlayer1StartingRound()
            ? (_currentUnitOfPlayer1, _currentUnitOfPlayer2, IdOfPlayer1)
            : (_currentUnitOfPlayer2, _currentUnitOfPlayer1, IdOfPlayer2);
        _followUpController.ManageFollowup(attacker, defender, attackerId);
    }

    private void ManageEndHpChange()
    {
        var (unit1, unit2) = IsPlayer1StartingRound()
            ? (_currentUnitOfPlayer1, _currentUnitOfPlayer2)
            : (_currentUnitOfPlayer2, _currentUnitOfPlayer1);
        _outOfCombatDamageController.ManageHpChangeAtTheEndOfCombat(unit1, unit2);
    }

    private void ResetUnitBonuses()
    {
        _attackController.ResetAllSkills();
    }

    private void DisplayRemainingHp()
    {
        var (unit1, unit2) = IsPlayer1StartingRound()
            ? (_currentUnitOfPlayer1, _currentUnitOfPlayer2)
            : (_currentUnitOfPlayer2, _currentUnitOfPlayer1);
        _view.ShowHp(unit1, unit2);
    }

    private void LogGameUpdates()
    {
        UpdateLastOpponents();
        ResetAttackFlags();
        UpdateCombatParticipationFlags();
    }

    private void UpdateLastOpponents()
    {
        _currentUnitOfPlayer1.LastOpponentName = _currentUnitOfPlayer2.Name;
        _currentUnitOfPlayer2.LastOpponentName = _currentUnitOfPlayer1.Name;
    }

    private void ResetAttackFlags()
    {
        _currentUnitOfPlayer1.HasAttackedThisRound = false;
        _currentUnitOfPlayer2.HasAttackedThisRound = false;
    }

    private void UpdateCombatParticipationFlags()
    {
        if (IsPlayer1StartingRound())
        {
            _currentUnitOfPlayer2.HasBeenBeenInACombatStartedByTheOpponent = true;
            _currentUnitOfPlayer1.HasStartedACombat = true;
        }
        else
        {
            _currentUnitOfPlayer2.HasStartedACombat = true;
            _currentUnitOfPlayer1.HasBeenBeenInACombatStartedByTheOpponent = true;
        }
    }

    private void EliminateDeadUnits()
    {
        EliminateDeadUnit(_player1.Units, _currentUnitOfPlayer1, _currentUnitNumberOfPlayer1);
        EliminateDeadUnit(_player2.Units, _currentUnitOfPlayer2, _currentUnitNumberOfPlayer2);
    }

    private static void EliminateDeadUnit(UnitsList units, Unit unit, int unitIndex)
    {
        if (IsUnitDead(unit))
        {
            units.EliminateUnit(unitIndex);
        }
    }

    private static bool IsUnitDead(IUnit unit)
    {
        return unit.Hp == 0;
    }
    
    private void IncrementRound()
    {
        _currentRound++;
    }
    
    public bool IsGameTerminated()
    {
        return _attackController.IsGameTerminated();
    }
    
    public int GetWinner()
    {
        return _attackController.GetWinner();
    }
}