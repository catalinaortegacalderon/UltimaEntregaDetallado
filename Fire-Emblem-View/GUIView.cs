using ConsoleApp1.EncapsulatedLists;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem_GUI;

namespace Fire_Emblem_View;

public class GuiView : IView
{
    private readonly FireEmblemWindow _window;
    
    private const int IdOfPlayer1 = 0;
    private const int IdOfPlayer2 = 1;

    private Unit[] _team1;
    private Unit[] _team2;

    public GuiView(FireEmblemWindow window)
    {
        this._window = window;
    }
    
    public int AskPlayerForTheChosenFile(string[] files)
    {
        return 0;
    }

    public void AnnounceTeamsAreNotValid()
    {
        // todo: muestra el mensaje pero sigue el flujo, creo que es program
        _window.ShowInvalidTeamMessage();
    }

    public void UpdateTeams(Player player1, Player player2)
    {
        var team1 = player1.Units.Where(unit => unit.Name != "").ToArray();
        var team2 = player2.Units.Where(unit => unit.Name != "").ToArray();

        _team1 = team1;
        _team2 = team2;

        _window.UpdateTeams(team1, team2);

    }

    public int[] AskBothPlayersForTheChosenUnit(PlayersList players, int currentAttacker)
    {
        // todo: arreglar
        Console.WriteLine("paso por aqui, no implementado, chosen unit, solo retorno 0");
        return new []{0,0};
    }

    public int AskAPlayerForTheChosenUnit(int playerNumber, UnitsList units)
    {
        // todo: arreglar
        Console.WriteLine("paso por aqui, no implementado, chosen unit, solo retorno 0");
        return 0;
    }

    public void ShowRoundInformation(int currentRound, string attackersName, int playersNumber)
    {
        return;
    }

    public void AnnounceAdvantage(Unit unitWithAdvantage, Unit unitWithoutAdvantage)
    {
        return;
    }

    public void AnnounceThereIsNoAdvantage()
    {
        return;
    }

    public void ShowAllSkills(Unit unit)
    {
        return;
    }

    public void AnnounceHpRecuperation(Unit unitThatRecuperatesHp, int amount, int finalHp)
    {
        return;
    }

    public void AnnounceDamageBeforeCombat(Unit unitThatRecievesDamage, int damage)
    {
        return;
    }

    public void AnnounceCurationAfterCombat(Unit unitThatRecievesCuration, int recuperatedAmount)
    {
        return;
    }

    public void AnnounceDamageAfterCombat(Unit unitThatRecievesDamage, int damage)
    {
        return;
    }

    public void ShowAttack(string attackersName, string defensorsName, int damage)
    {
        return;
    }

    public void AnnounceASpecificUnitCantDoAFollowup(string name)
    {
        return;
    }

    public void AnnounceNoUnitCanDoAFollowup()
    {
        return;
    }

    public void ShowHp(Unit roundStarterUnit, Unit opponentsUnit)
    {
        return;
    }

    public void AnnounceWinner(int winnersNumber)
    {
        if (winnersNumber == 0)
            _window.CongratulateTeam1(_team1);
        else
        {
            _window.CongratulateTeam2(_team2);
        }
    }
    
}