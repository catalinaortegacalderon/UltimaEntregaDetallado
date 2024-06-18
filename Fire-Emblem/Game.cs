using ConsoleApp1;
using ConsoleApp1.DataTypes;
using ConsoleApp1.Exceptions;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem_View;

namespace Fire_Emblem;
public class Game
{
    private const int IdOfPlayer1 = 0;
    private const int IdOfPlayer2 = 1;
    private readonly string _teamsFolder;
    
    private readonly GameView _view;
    
    private int _currentRound;
    
    private int _currentUnitNumberOfPlayer1;
    private int _currentUnitNumberOfPlayer2;
    private Unit _currentUnitOfPlayer1;
    private Unit _currentUnitOfPlayer2;
    
    private GameAttacksController _attackController;
    private FollowUpController _followUpController;
    private OutOfCombatDamageManager _outOfCombatDamageManager;
    
    // todo: hacer un manager
    // se encarga de cosas de game y de game attacks controler, todos los manage

    public Game(GameView view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
        _currentRound = 1;
        _outOfCombatDamageManager = new OutOfCombatDamageManager(view);
    }

    public void Play()
    {
        try
        {
            TryToPlay();
        }
        catch (InvalidTeamException)
        {
            _view.AnnounceTeamsAreNotValid();
        }
    }

    private void TryToPlay()
    {
        var teamFile = GetTeamFile();
        var gameAttacksControllerBuilder = new GameAttacksControllerBuilder();
        _attackController = gameAttacksControllerBuilder.BuildGameController(File.ReadAllLines(teamFile), _view);
        _followUpController = new FollowUpController(_attackController, _view);

        while (IsGameNotTerminated())
        {
            PlayOneRound();
        }

        _view.AnnounceWinner(_attackController.GetWinner());
    }

    private bool IsGameNotTerminated()
    {
        return !_attackController.IsGameTerminated();
    }

    private string GetTeamFile()
    {
        var files = ReadTeamsFiles();
        var fileNumInput = _view.AskPlayerForTheChosenFile(files);

        if (!FileChecker.IsGameValid(files[fileNumInput]))
        {
            throw new InvalidTeamException();
        }

        return files[fileNumInput];
    }

    private string[] ReadTeamsFiles()
    {
        var files = Directory.GetFiles(_teamsFolder);
        Array.Sort(files);
        return files;
    }

    private void PlayOneRound()
    {
        _attackController.RestartRound();
        
        _attackController.SetCurrentAttacker(IsPlayer1TheRoundStarter() ? IdOfPlayer1 : IdOfPlayer2);
        StartRound();
        _currentRound++;
    }

    private bool IsPlayer1TheRoundStarter()
    {
        return _currentRound % 2 == 1;
    }

    private void StartRound()
    {
        // todo: ACA SE MANEJA TODO
        GetAndSetPlayersChosenUnit();
        PrintRound();
        CheckAlliesConditionsForSkills();
        InitializeRound();
        ManageHpChangeAtTheBeginningOfTheCombat(); 
        ExecuteAttacks();
        FollowUp();
        ManageHpChangeAtTheEndOfTheCombat();
        ResetUnitsBonus();
        ShowLeftoverHp();
        UpdateGameLogs();
        EliminateLooserUnit();
    }

    private void ManageHpChangeAtTheEndOfTheCombat()
    {
        if (IsPlayer1TheRoundStarter())
        {
            _outOfCombatDamageManager.ManageHpChangeAtTheEndOfTheCombat(
                _currentUnitOfPlayer1, _currentUnitOfPlayer2);
        }
        else
        {
            _outOfCombatDamageManager.ManageHpChangeAtTheEndOfTheCombat(
                _currentUnitOfPlayer2, _currentUnitOfPlayer1);
        }
    }

    private void GetAndSetPlayersChosenUnit()
    {
        GetChosenUnits();
        SetUnits();
    }

    private void GetChosenUnits()
    {
        int[] unitsNumber = _view.AskBothPlayersForTheChosenUnit(_attackController.GetPlayers(),
            _attackController.GetCurrentAttacker());

        _currentUnitNumberOfPlayer1 = unitsNumber[IdOfPlayer1];
        _currentUnitNumberOfPlayer2 = unitsNumber[IdOfPlayer2];
    }


    private void SetUnits()
    {
        var players = _attackController.GetPlayers();

        var player1 = players.GetPlayerById(IdOfPlayer1);
        var unitsOfPlayer1 = player1.Units;
        
        var player2 = players.GetPlayerById(IdOfPlayer2);
        var unitsOfPlayer2 = player2.Units;
        
        _currentUnitOfPlayer1 = unitsOfPlayer1.GetUnitByIndex(_currentUnitNumberOfPlayer1);
        _currentUnitOfPlayer2 = unitsOfPlayer2.GetUnitByIndex(_currentUnitNumberOfPlayer2);
    }

    private void PrintRound()
    {
        int playerNumber = _attackController.GetCurrentAttacker() == IdOfPlayer1 ? 1 : 2;
        _view.ShowRoundInformation(_currentRound, GetCurrentAttackersName(), playerNumber);
    }

    private string GetCurrentAttackersName()
    {
        return IsPlayer1TheRoundStarter() ? _currentUnitOfPlayer1.Name : _currentUnitOfPlayer2.Name;
    }

    private void CheckAlliesConditionsForSkills()
    {
        CheckPlayerAlliesConditions(IdOfPlayer1);
        CheckPlayerAlliesConditions(IdOfPlayer2);
    }

    private void CheckPlayerAlliesConditions(int playerId)
    {
        // todo: aca queda desatualizado el param siempre, solo esta actualizado el de la unit actual
        var playersUnitNumber = _currentUnitNumberOfPlayer2;
        if (playerId == IdOfPlayer1)
        {
            playersUnitNumber = _currentUnitNumberOfPlayer1;
        }
        var players = _attackController.GetPlayers();
        var player = players.GetPlayerById(playerId);
        var unitsOfThePlayer = player.Units;
        bool hasAllyWithMagic = false;
        int counter = 0;
        
        foreach (var unit in unitsOfThePlayer)
        {
            if (unit.CurrentHp > 0 && unit.Weapon == Weapon.Magic  && counter != playersUnitNumber)
                hasAllyWithMagic = true;
            counter++;
        }
        foreach (var unit in unitsOfThePlayer)
        {
            unit.HasAnAllyWithMagic = hasAllyWithMagic;
        }
    }

    private void InitializeRound()
    {
        Unit attackingUnit;
        Unit defensiveUnit;
        
        if (IsPlayer1TheRoundStarter())
        {
            attackingUnit = _currentUnitOfPlayer1;
            defensiveUnit = _currentUnitOfPlayer2;
        }
        else
        {
            attackingUnit = _currentUnitOfPlayer2;
            defensiveUnit = _currentUnitOfPlayer1;
        }
        
        _attackController.InitializeRound(attackingUnit, defensiveUnit);
        
    }


    private void ManageHpChangeAtTheBeginningOfTheCombat()
    {
        // todo: hago esto mucho, pensar manera mas eficiente
        if (IsPlayer1TheRoundStarter())
        {
            _outOfCombatDamageManager.ManageDamageAtTheBeginningOfTheCombat(
                _currentUnitOfPlayer1, _currentUnitOfPlayer2);
        }
        else
        {
            _outOfCombatDamageManager.ManageDamageAtTheBeginningOfTheCombat(
                _currentUnitOfPlayer2, _currentUnitOfPlayer1);
        }
    }

    private void ExecuteAttacks()
    {
        if (IsPlayer1TheRoundStarter())
        {
            ExecuteAtacksInOrder(_currentUnitOfPlayer1, _currentUnitOfPlayer2);
        }
        else
        {
            ExecuteAtacksInOrder(_currentUnitOfPlayer2, _currentUnitOfPlayer1);
        }
    }

    private void ExecuteAtacksInOrder(Unit firstAttacker, Unit secondAttacker)
    {
        _attackController.GenerateAnAttackBetweenTwoUnits(AttackType.FirstAttack, 
            firstAttacker, 
            secondAttacker);
        _attackController.ChangeAttacker();
        if (IsTheDefensorAbleToCounterAttack())
        {
            _attackController.GenerateAnAttackBetweenTwoUnits(AttackType.SecondAttack, 
                secondAttacker,
                firstAttacker);
        }
        
    }

    private bool IsTheDefensorAbleToCounterAttack()
    {
        if (IsPlayer1TheRoundStarter())
        {
            return !_currentUnitOfPlayer2.CombatEffects.HasCounterAttackDenial || 
                   _currentUnitOfPlayer2.CombatEffects.HasNeutralizationOfCounterattackDenial;
        }
        return !_currentUnitOfPlayer1.CombatEffects.HasCounterAttackDenial || 
               _currentUnitOfPlayer1.CombatEffects.HasNeutralizationOfCounterattackDenial;
    }
    
    private void FollowUp()
    {
        if (IsPlayer1TheRoundStarter())
            _followUpController.ManageFollowup(
                _currentUnitOfPlayer1, _currentUnitOfPlayer2,
                IdOfPlayer1);
        else
        {
            _followUpController.ManageFollowup(  
                _currentUnitOfPlayer2, _currentUnitOfPlayer1,
                IdOfPlayer2);
        }
    }


    private void ResetUnitsBonus()
    {
        _attackController.ResetAllSkills();
    }

    private void ShowLeftoverHp()
    {
        if (IsPlayer1TheRoundStarter())
        {
            _view.ShowHp(_currentUnitOfPlayer1, _currentUnitOfPlayer2);
        }
        else
        {
            _view.ShowHp(_currentUnitOfPlayer2, _currentUnitOfPlayer1);
        }
    }

        private void UpdateGameLogs()
        {
            // todo: separar en tres funciones
            _attackController.UpdateLastOpponents();

            _currentUnitOfPlayer1.HasAttackedThisRound = false;
            _currentUnitOfPlayer2.HasAttackedThisRound = false;

            if (IsPlayer1TheRoundStarter())
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

    private void EliminateLooserUnit()
    {
        var players = _attackController.GetPlayers();
        if (IsUnitDead(_currentUnitOfPlayer1))
        {
            var player1 = players.GetPlayerById(IdOfPlayer1);
            var unitsOfPlayer1 = player1.Units;
                
            unitsOfPlayer1.EliminateUnit(_currentUnitNumberOfPlayer1);
        }

        if (IsUnitDead(_currentUnitOfPlayer2))
        {
            var player2 = players.GetPlayerById(IdOfPlayer2);
            var unitsOfPlayer2 = player2.Units;
                
            unitsOfPlayer2.EliminateUnit(_currentUnitNumberOfPlayer2);
        }
    }

    private bool IsUnitDead(Unit unit)
    {
        return unit.CurrentHp == 0;
    }
}