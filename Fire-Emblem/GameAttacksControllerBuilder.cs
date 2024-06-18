using System.Text.Json;
using ConsoleApp1.EncapsulatedLists;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class GameAttacksControllerBuilder
{
    private const int PlayerCount = 2;
    private readonly int[] _unitCounters = new int[PlayerCount];
    private readonly Unit[][] _units = new Unit[PlayerCount][];
    private int _currentPlayerNumber;

    private const int IdOfPlayer1 = 0;
    private const int IdOfPlayer2 = 1;

    public GameAttacksControllerBuilder() 
        => InitializeUnits();

    private void InitializeUnits()
    {
        for (int i = 0; i < PlayerCount; i++)
        {
            _units[i] = [new Unit(), new Unit(), new Unit()];
        }
    }

    public GameAttacksController BuildGameController(string[] fileLines, GameView view)
    {
        ProcessFileToCreateUnitsAndSkills(fileLines);

        var players = CreatePlayers();

        return new GameAttacksController(players[0], players[1], view);
    }

    private void ProcessFileToCreateUnitsAndSkills(string[] fileLines)
    {
        foreach (var line in fileLines)
        {
            if (line == "Player 1 Team")
                SetCurrentPlayerNumber(IdOfPlayer1);
            else if (line == "Player 2 Team")
                SetCurrentPlayerNumber(IdOfPlayer2);
            else
                CreateUnitsAndSkills(line);
        }
    }

    private void SetCurrentPlayerNumber(int id) 
        => _currentPlayerNumber = id;

    private void CreateUnitsAndSkills(string line)
    {
        var unitInfo = CreateUnits(line);
        var currentPlayersUnitNumber = _unitCounters[_currentPlayerNumber];
        var currentPlayersUnits = _units[_currentPlayerNumber];
        var currentUnit = currentPlayersUnits[currentPlayersUnitNumber];

        CreateSkills(currentUnit.Skills, unitInfo);

        _unitCounters[_currentPlayerNumber]++;
    }

    private string[] CreateUnits(string line)
    {
        var unitInfo = line.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        var unitName = unitInfo[0].Trim();
        var jsonUnits = LoadJsonUnits();

        var jsonUnit = jsonUnits.FirstOrDefault(u => u.Name == unitName);
        if (jsonUnit != null) 
            CreateUnit(jsonUnit);

        return unitInfo;
    }

    private static List<JsonUnit> LoadJsonUnits()
    {
        var json = File.ReadAllText("characters.json");
        return JsonSerializer.Deserialize<List<JsonUnit>>(json);
    }

    private void CreateUnit(JsonUnit jsonUnit)
    {
        var unitsOfPlayer = _units[_currentPlayerNumber];
        var unitIndex = _unitCounters[_currentPlayerNumber];

        unitsOfPlayer[unitIndex] = new Unit(
            jsonUnit.Name,
            jsonUnit.Weapon,
            jsonUnit.Gender,
            Convert.ToInt32(jsonUnit.HP),
            Convert.ToInt32(jsonUnit.HP),
            Convert.ToInt32(jsonUnit.Atk),
            Convert.ToInt32(jsonUnit.Spd),
            Convert.ToInt32(jsonUnit.Def),
            Convert.ToInt32(jsonUnit.Res)
        );
    }

    private static void CreateSkills(SkillsList skills, string[] unitInfo)
    {
        if (DoesNotHaveSkills(unitInfo)) 
            return;

        var skillNames = unitInfo[1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < skillNames.Length; i++)
        {
            SkillConstructor.Construct(skills, skillNames[i].Trim(), i);
        }
    }

    private static bool DoesNotHaveSkills(string[] unitInfo) 
        => unitInfo.Length <= 1;

    private Player[] CreatePlayers()
    {
        var players = new Player[PlayerCount];
        
        players[IdOfPlayer1] = CreatePlayer(IdOfPlayer1);
        players[IdOfPlayer2] = CreatePlayer(IdOfPlayer2);

        return players;
    }

    private Player CreatePlayer(int playerId)
    {
        var player = new Player
        {
            AmountOfUnits = _unitCounters[playerId]
        };

        for (int i = 0; i < _units[playerId].Length; i++)
        {
            player.Units.AddUnit(i, _units[playerId][i]);
        }

        return player;
    }
}
