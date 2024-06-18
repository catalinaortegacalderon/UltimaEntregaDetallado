using ConsoleApp1;
using ConsoleApp1.DataTypes;
using ConsoleApp1.EncapsulatedLists;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class GameAttacksController
{
    // tal vez tenga mas sentido que players este en game y no aca
    private readonly PlayersList _players = new();
    private readonly GameView _view;
    private DamageCalculator _damageCalculator;
    private OutOfCombatDamageManager _outOfCombatDamageManager;
    private Unit _currentAttackingUnit;
    private Unit _currentDefensiveUnit;
    private int _attackValue;
    private int _currentAttackerId;
    private bool _gameIsTerminated;
    private bool _roundIsTerminated;
    private int _winner;
    
    // TODO: ideaa, aca manejar los tres casos, ataque contraataque y followup de manera diferente
    // no en el deesarollo sino en como se "autorizan"

    public GameAttacksController(Player firstPlayer, Player secondPlayer, GameView view)
    {
        _currentAttackerId = 0;
        _players.AddPlayer(firstPlayer);
        _players.AddPlayer(secondPlayer);
        _view = view;
        _outOfCombatDamageManager = new OutOfCombatDamageManager(view);
    }

    public void GenerateAnAttackBetweenTwoUnits(AttackType typeOfCurrentAttack, Unit atackingUnit, 
        Unit defensiveUnit)
    {
        if (RoundIsTerminated()) 
            return;

        SetAttackingAndDefensiveUnits(atackingUnit, defensiveUnit);

        if (typeOfCurrentAttack == AttackType.FirstAttack)
        {
            //InitializeRound();
        }

        CalculateAndApplyDamage(typeOfCurrentAttack);
        ShowWhoAttacksWho();
        ManageHpRecuperationInEveryAttack();
    }

    private bool RoundIsTerminated() 
        => _gameIsTerminated || _roundIsTerminated;

    private void SetAttackingAndDefensiveUnits(Unit atackingUnit, Unit defensiveUnit)
    {
        _currentAttackingUnit = atackingUnit;
        _currentDefensiveUnit = defensiveUnit;

        _currentAttackingUnit.IsAttacking = true;
        _currentAttackingUnit.HasAttackedThisRound = true;
        _currentDefensiveUnit.IsAttacking = false;
    }

    public void InitializeRound(Unit atackingUnit, Unit defensiveUnit)
    {
        SetAttackingAndDefensiveUnits(atackingUnit, defensiveUnit);
        _currentAttackingUnit.StartedTheRound = true;
        _currentDefensiveUnit.StartedTheRound = false;
        ActivateSkills();
        PrintStartingParameters();
    }
    
    private void ActivateSkills()
    {
        SkillsActivator.ActivateSkills(_currentAttackingUnit, _currentDefensiveUnit);
    }
    
    private void PrintStartingParameters()
    {
        ShowAdvantages();
        PrintSkillsInfo();
    }
    
    private void ShowAdvantages()
    {
        var attackingWeapon = _currentAttackingUnit.Weapon;
        var defensiveWeapon = _currentDefensiveUnit.Weapon;

        if (DamageCalculator.IsNoAdvantage(defensiveWeapon, attackingWeapon))
        {
            _view.AnnounceThereIsNoAdvantage();
        }
        else if (DamageCalculator.DoesAttackerHaveAdvantage(attackingWeapon, defensiveWeapon))
        {
            _view.AnnounceAdvantage(_currentAttackingUnit, _currentDefensiveUnit);
        }
        else
        {
            _view.AnnounceAdvantage(_currentDefensiveUnit, _currentAttackingUnit);
        }
    }

    private void PrintSkillsInfo()
    {
        _view.ShowAllSkills(_currentAttackingUnit);
        _view.ShowAllSkills(_currentDefensiveUnit);
    }

    private void CalculateAndApplyDamage(AttackType typeOfCurrentAttack)
    {
        _damageCalculator = new DamageCalculator(_currentAttackingUnit, _currentDefensiveUnit, typeOfCurrentAttack);
        _attackValue = _damageCalculator.CalculateAttack();

        if (_attackValue >= _currentDefensiveUnit.CurrentHp)
        {
            _roundIsTerminated = true;
            _currentDefensiveUnit.CurrentHp = 0;
            ReduceUnitAmount();
            CheckIfGameIsTerminated();
        }
        else
        {
            _currentDefensiveUnit.CurrentHp -= _attackValue;
        }
    }

    private void ManageHpRecuperationInEveryAttack()
    {
        _outOfCombatDamageManager.ManaManageHpRecuperationInEveryAttack(_currentAttackingUnit, _currentDefensiveUnit,
            _attackValue);
        
    }
    
    private void ReduceUnitAmount()
    {
        var opponentPlayerId = _currentAttackerId == 0 ? 1 : 0;
        _players.GetPlayerById(opponentPlayerId).AmountOfUnits -= 1;
    }

    private void CheckIfGameIsTerminated()
    {
        if (HasNoUnits(0))
        {
            _winner = 1;
            _gameIsTerminated = true;
        }
        else if (HasNoUnits(1))
        {
            _winner = 0;
            _gameIsTerminated = true;
        }
    }
    
    private bool HasNoUnits(int playerId)
    {
        var player = _players.GetPlayerById(playerId);
        return player.AmountOfUnits == 0;
    }
    
    private void ShowWhoAttacksWho()
    {
        _view.ShowAttack(_currentAttackingUnit.Name, _currentDefensiveUnit.Name, _attackValue);
    }
    
    public void ResetAllSkills()
    {
        ResetUnitSkills(_currentAttackingUnit);
        ResetUnitSkills(_currentDefensiveUnit);
    }

    private void ResetUnitSkills(Unit unit)
    {
        DataStructuresResetter.ResetBonusPenaltiesAndNeutralizersToASpecificValue(unit.ActiveBonus, 
            0);
        DataStructuresResetter.ResetBonusPenaltiesAndNeutralizersToASpecificValue(unit.ActivePenalties, 
            0);
        DataStructuresResetter.ResetBonusPenaltiesAndNeutralizersToASpecificValue(unit.ActiveBonusNeutralizer, 
            1);
        DataStructuresResetter.ResetBonusPenaltiesAndNeutralizersToASpecificValue(unit.ActivePenaltiesNeutralizer, 
            1);
        DataStructuresResetter.ResetDamageGameStructure(unit.DamageEffects);
        DataStructuresResetter.ResetCombatEffects(unit.CombatEffects);
        
    }

    public bool IsGameTerminated() 
        => _gameIsTerminated;

    public void RestartRound() 
        => _roundIsTerminated = false;

    public int GetWinner() 
        => _winner + 1;

    public int GetCurrentAttacker() 
        => _currentAttackerId;

    public void SetCurrentAttacker(int value)
    { 
        _currentAttackerId = value;
    }

    public void ChangeAttacker()
    {
        _currentAttackerId = _currentAttackerId == 0 ? 1 : 0;
    }

    public void UpdateLastOpponents()
    {
        // todo: tal vez esto deberia ir en game
        _currentAttackingUnit.LastOpponentName = _currentDefensiveUnit.Name;
        _currentDefensiveUnit.LastOpponentName = _currentAttackingUnit.Name;
    }

    public PlayersList GetPlayers() 
        => _players;
}
