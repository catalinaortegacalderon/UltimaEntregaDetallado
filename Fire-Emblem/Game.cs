using ConsoleApp1;
using ConsoleApp1.DataTypes;
using ConsoleApp1.EncapsulatedLists;
using ConsoleApp1.Exceptions;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem_View;

namespace Fire_Emblem;
public class Game
{
    private const int IdOfPlayer1 = 0;
    private const int IdOfPlayer2 = 1;
    private readonly string _teamsFolder;
    
    private readonly IView _view;
    
    private int _currentRound;

    private Player _player1;
    private Player _player2;
    
    private int _currentUnitNumberOfPlayer1;
    private int _currentUnitNumberOfPlayer2;
    private Unit _currentUnitOfPlayer1;
    private Unit _currentUnitOfPlayer2;
    
    private GameAttacksController _attackController;
    private FollowUpController _followUpController;
    private readonly OutOfCombatDamageController _outOfCombatDamageController;
    
    // todo: hacer un manager
    // todo: hay muchas skills parecidas, ver si lo arreglo o no
    // todo: consistencia, todos los constructores arriba o todos como metodo, creo que mejor todo como metodo

    public Game(IView view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
        _currentRound = 1;
        _outOfCombatDamageController = new OutOfCombatDamageController(view);
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
        BuildControllers();
        SetPlayers();

        while (IsGameNotTerminated())
        {
            PlayOneRound();
        }

        _view.AnnounceWinner(_attackController.GetWinner());
    }

    private void BuildControllers()
    {
        var teamFile = GetTeamFile();
        var gameAttacksControllerBuilder = new GameAttacksControllerBuilder();
        _attackController = gameAttacksControllerBuilder.BuildGameController(File.ReadAllLines(teamFile), _view);
        UpdateTeams();
        _followUpController = new FollowUpController(_attackController, _view);
    }
    
    private void SetPlayers()
    {
        var players = _attackController.GetPlayers();
        _player1 = players.GetPlayerById(IdOfPlayer1);
        _player2 = players.GetPlayerById(IdOfPlayer2);
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
        UpdateTeams();
        _currentRound++;
    }

    private void UpdateTeams()
    {
        _view.UpdateTeams(_player1, _player2);
    }

    private bool IsPlayer1TheRoundStarter()
    {
        return _currentRound % 2 == 1;
    }

    private void StartRound()
    {
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
        EliminateLoserUnits();
    }

    private void ManageHpChangeAtTheEndOfTheCombat()
    {
        if (IsPlayer1TheRoundStarter())
        {
            _outOfCombatDamageController.ManageHpChangeAtTheEndOfCombat(
                _currentUnitOfPlayer1, _currentUnitOfPlayer2);
        }
        else
        {
            _outOfCombatDamageController.ManageHpChangeAtTheEndOfCombat(
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
        var unitsOfPlayer1 = _player1.Units;
        _currentUnitOfPlayer1 = unitsOfPlayer1.GetUnitByIndex(_currentUnitNumberOfPlayer1);
        
        var unitsOfPlayer2 = _player2.Units;
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
        CheckPlayerAlliesConditions(_player1, _currentUnitOfPlayer1);
        CheckPlayerAlliesConditions(_player2, _currentUnitOfPlayer2);
    }

    private void CheckPlayerAlliesConditions(Player player, Unit playersCurrentUnit)
    {
        
        var unitsOfThePlayer = player.Units;
        var hasAllyWithMagic = HasAllyWithMagic(playersCurrentUnit, unitsOfThePlayer);
        playersCurrentUnit.HasAnAllyWithMagic = hasAllyWithMagic;
        
    }

    private static bool HasAllyWithMagic(Unit playersCurrentUnit, UnitsList unitsOfThePlayer)
    {
        bool hasAllyWithMagic = false;

        foreach (var unit in unitsOfThePlayer)
        {
            if (IsAllyAlliveAndHasMagic(playersCurrentUnit, unit))
                hasAllyWithMagic = true;
        }

        return hasAllyWithMagic;
    }

    private static bool IsAllyAlliveAndHasMagic(Unit playersCurrentUnit, Unit unit)
    {
        return unit.Hp > 0 && unit.WeaponType == WeaponType.Magic  && unit != playersCurrentUnit;
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
            _outOfCombatDamageController.ManageDamageAtTheBeginningOfCombat(
                _currentUnitOfPlayer1, _currentUnitOfPlayer2);
        }
        else
        {
            _outOfCombatDamageController.ManageDamageAtTheBeginningOfCombat(
                _currentUnitOfPlayer2, _currentUnitOfPlayer1);
        }
    }

    private void ExecuteAttacks()
    {
        if (IsPlayer1TheRoundStarter())
        {
            ExecuteAttacksInOrder(_currentUnitOfPlayer1, _currentUnitOfPlayer2);
        }
        else
        {
            ExecuteAttacksInOrder(_currentUnitOfPlayer2, _currentUnitOfPlayer1);
        }
    }

    private void ExecuteAttacksInOrder(Unit firstAttacker, Unit secondAttacker)
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
            UpdateLastOpponents();

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
        
        
        public void UpdateLastOpponents()
        {
            _currentUnitOfPlayer1.LastOpponentName = _currentUnitOfPlayer2.Name;
            _currentUnitOfPlayer2.LastOpponentName = _currentUnitOfPlayer1.Name;
        }

    private void EliminateLoserUnits()
    {
        EliminateLoserUnit(_player1.Units, _currentUnitOfPlayer1, _currentUnitNumberOfPlayer1);
        EliminateLoserUnit(_player2.Units, _currentUnitOfPlayer2, _currentUnitNumberOfPlayer2);
    }

    private static void EliminateLoserUnit(UnitsList units, Unit unit, int unitNumber)
    {
        if (IsUnitDead(unit))
            units.EliminateUnit(unitNumber);
    }

    private static bool IsUnitDead(Unit unit)
    {
        return unit.Hp == 0;
    }
}