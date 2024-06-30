using ConsoleApp1;
using ConsoleApp1.Exceptions;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem_View;
using Fire_Emblem.Controllers;
using System;
using System.IO;

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

        private RoundController _roundController;

        public Game(IView view, string teamsFolder)
        {
            _view = view;
            _teamsFolder = teamsFolder;
            _currentRound = 1;
        }

        public void Play()
        {
            try
            {
                InitializeGame();
                PlayRounds();
                AnnounceWinner();
            }
            catch (InvalidTeamException)
            {
                _view.AnnounceTeamsAreNotValid();
            }
        }

        private void InitializeGame()
        {
            BuildPlayers();
            BuildRoundController();
            UpdateTeams();
        }

        private void BuildPlayers()
        {
            string teamFile = GetValidTeamFile();
            Player[] players = new PlayersConstructor().BuildPlayers(File.ReadAllLines(teamFile));
            SetPlayers(players);
        }
        
        private void BuildRoundController()
        {
            _roundController = new RoundController(_view, _player1, _player2);
        }

        private string GetValidTeamFile()
        {
            string[] files = GetSortedTeamFiles();
            int chosenFileIndex = _view.AskPlayerForTheChosenFile(files);

            if (!FileChecker.IsGameValid(files[chosenFileIndex]))
            {
                throw new InvalidTeamException();
            }

            return files[chosenFileIndex];
        }

        private string[] GetSortedTeamFiles()
        {
            string[] files = Directory.GetFiles(_teamsFolder);
            Array.Sort(files);
            return files;
        }

        private void SetPlayers(Player[] players)
        {
            _player1 = players[IdOfPlayer1];
            _player2 = players[IdOfPlayer2];
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
            return _roundController.IsGameTerminated();
        }

        private void PlayOneRound()
        {
            ExecuteRound();
            UpdateTeams();
            IncrementRound();
        }

        private void ExecuteRound()
        {
            _roundController.ExecuteRound();
        }

        private void AnnounceWinner()
        {
            _view.AnnounceWinner(_roundController.GetWinner());
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
