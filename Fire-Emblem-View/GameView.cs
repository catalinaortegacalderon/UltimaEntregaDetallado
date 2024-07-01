using ConsoleApp1.EncapsulatedLists;
using ConsoleApp1.GameDataStructures;

namespace Fire_Emblem_View;

public class GameView : IView
{
    private readonly View _view;
    private const int IdOfPlayer1 = 0;
    private const int IdOfPlayer2 = 1;

    public GameView(View view)
    {
        _view = view;
    }

    public int AskPlayerForTheChosenFile(string[] files)
    {
        ShowTeamFilesToUser(files);
        if (int.TryParse(_view.ReadLine(), out int fileIndex))
            return fileIndex;
        return AskPlayerForTheChosenFile(files);
    }

    public void AnnounceTeamsAreNotValid()
    {
        _view.WriteLine("Archivo de equipos no válido");
    }

    public void UpdateTeams(Player player1, Player player2)
    {
    }

    public int[] AskBothPlayersForTheChosenUnit(PlayersList players, int currentAttacker)
    {
        var player1 = players.GetPlayerById(IdOfPlayer1);
        var player2 = players.GetPlayerById(IdOfPlayer2);

        int currentUnitNumberOfPlayer1;
        int currentUnitNumberOfPlayer2;

        if (IsPlayer1TheCurrentAttacker(currentAttacker))
        {
            currentUnitNumberOfPlayer1 = AskAPlayerForTheChosenUnit(IdOfPlayer1, player1.Units);
            currentUnitNumberOfPlayer2 = AskAPlayerForTheChosenUnit(IdOfPlayer2, player2.Units);
        }
        else
        {
            currentUnitNumberOfPlayer2 = AskAPlayerForTheChosenUnit(IdOfPlayer2, player2.Units);
            currentUnitNumberOfPlayer1 = AskAPlayerForTheChosenUnit(IdOfPlayer1, player1.Units);
        }

        return [currentUnitNumberOfPlayer1, currentUnitNumberOfPlayer2];
    }

    private static bool IsPlayer1TheCurrentAttacker(int currentAttacker)
    {
        return currentAttacker == IdOfPlayer1;
    }

    private int AskAPlayerForTheChosenUnit(int playerNumber, UnitsList units)
    {
        PrintUnitOptions(playerNumber, units);
        if (int.TryParse(_view.ReadLine(), out int chosenUnitNumber))
        {
            return chosenUnitNumber;
        }
        return AskAPlayerForTheChosenUnit(playerNumber, units);
    }

    public void ShowRoundInformation(int currentRound, string attackersName, int playersNumber)
    {
        _view.WriteLine($"Round {currentRound}: {attackersName} (Player {playersNumber}) comienza");
    }

    public void AnnounceAdvantage(Unit unitWithAdvantage, Unit unitWithoutAdvantage)
    {
        _view.WriteLine($"{unitWithAdvantage.Name} ({unitWithAdvantage.WeaponType}) " +
                        $"tiene ventaja con respecto a {unitWithoutAdvantage.Name} ({unitWithoutAdvantage.WeaponType})");
    }

    public void AnnounceThereIsNoAdvantage()
    {
        _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
    }

    public void ShowAllSkills(Unit unit)
    {
        SkillsPrinter.PrintAll(_view, unit);
    }

    public void AnnounceHpRecuperation(Unit unitThatRecuperatesHp, int amount, int finalHp)
    {
        _view.WriteLine($"{unitThatRecuperatesHp.Name} recupera {amount} HP luego de atacar " +
                        $"y queda con {finalHp} HP.");
    }

    public void AnnounceDamageBeforeCombat(Unit unitThatReceivesDamage, int damage)
    {
        _view.WriteLine($"{unitThatReceivesDamage.Name} recibe {damage} de daño antes de iniciar el combate " +
                        $"y queda con {unitThatReceivesDamage.Hp} HP");
    }

    public void AnnounceCurationAfterCombat(Unit unitThatReceivesCuration, int recuperatedAmount)
    {
        _view.WriteLine($"{unitThatReceivesCuration.Name} recupera {recuperatedAmount} HP despues del combate");
    }

    public void AnnounceDamageAfterCombat(Unit unitThatReceivesDamage, int damage)
    {
        _view.WriteLine($"{unitThatReceivesDamage.Name} recibe {damage} de daño despues del combate");
    }

    public void ShowAttack(string attackersName, string defendersName, int damage)
    {
        _view.WriteLine($"{attackersName} ataca a {defendersName} con {damage} de daño");
    }

    public void UpdateUnitsStatsDuringBattle(Unit unit1, Unit unit2)
    {
    }

    public void AnnounceUnitCannotFollowUp(string name)
    {
        _view.WriteLine($"{name} no puede hacer un follow up");
    }

    public void AnnounceNoUnitCanFollowUp()
    {
        _view.WriteLine("Ninguna unidad puede hacer un follow up");
    }

    public void ShowHp(Unit roundStarterUnit, Unit opponentsUnit)
    {
        _view.WriteLine($"{roundStarterUnit.Name} ({roundStarterUnit.Hp}) : {opponentsUnit.Name} " +
                        $"({opponentsUnit.Hp})");
    }

    public void AnnounceWinner(int winnersNumber)
    {
        _view.WriteLine($"Player {winnersNumber} ganó");
    }

    private void ShowTeamFilesToUser(string[] files)
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        for (int i = 0; i < files.Length; i++)
        {
            _view.WriteLine($"{i}: {Path.GetFileName(files[i])}");
        }
    }

    private void PrintUnitOptions(int playerNumber, UnitsList units)
    {
        var unitNumberCounter = 0;
        var playerNumberString = playerNumber == 0 ? "1" : "2";
        _view.WriteLine($"Player {playerNumberString} selecciona una opción");
        foreach (var unit in units)
        {
            if (unit.Name != "")
                _view.WriteLine(unitNumberCounter + ": " + unit.Name);
            unitNumberCounter++;
        }
    }
}