using ConsoleApp1;
using ConsoleApp1.Exceptions;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem_View;

namespace Fire_Emblem
{
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
            InitializeGame();
            PlayRounds();
            AnnounceWinner();
        }

        private void InitializeGame()
        {
            BuildControllers();
            SetPlayers();
            UpdateTeams();
        }

        private void BuildControllers()
        {
            var teamFile = GetValidTeamFile();
            _attackController =
                new GameAttacksControllerBuilder().BuildGameController(File.ReadAllLines(teamFile), _view);
            _followUpController = new FollowUpController(_attackController, _view);
        }

        private string GetValidTeamFile()
        {
            var files = GetSortedTeamFiles();
            var chosenFileIndex = _view.AskPlayerForTheChosenFile(files);

            if (!FileChecker.IsGameValid(files[chosenFileIndex]))
            {
                throw new InvalidTeamException();
            }

            return files[chosenFileIndex];
        }

        private string[] GetSortedTeamFiles()
        {
            var files = Directory.GetFiles(_teamsFolder);
            Array.Sort(files);
            return files;
        }

        private void SetPlayers()
        {
            var players = _attackController.GetPlayers();
            _player1 = players.GetPlayerById(IdOfPlayer1);
            _player2 = players.GetPlayerById(IdOfPlayer2);
        }

        private void PlayRounds()
        {
            while (!IsGameTerminated())
            {
                PlayOneRound();
            }
        }

        private bool IsGameTerminated()
        {
            return _attackController.IsGameTerminated();
        }

        private void PlayOneRound()
        {
            ResetRound();
            SetCurrentAttacker();
            ExecuteRound();
            UpdateTeams();
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

        private void ExecuteRound()
        {
            // todo: nose si es tan buena idea crearlo siempre
            var roundController = new RoundController(_view,_currentRound, _player1, _player2,
                _attackController, _followUpController, _outOfCombatDamageController);
            roundController.ExecuteRound();
        }

        private bool IsPlayer1StartingRound()
        {
            return _currentRound % 2 == 1;
        }

        private void AnnounceWinner()
        {
            _view.AnnounceWinner(_attackController.GetWinner());
        }

        private void UpdateTeams()
        {
            _view.UpdateTeams(_player1, _player2);
        }
        
        private void IncrementRound()
        {
            _currentRound++;
        }
    }
}