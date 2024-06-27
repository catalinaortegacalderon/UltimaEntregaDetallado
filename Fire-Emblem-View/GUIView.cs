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

    private Unit _unitTeam1;
    private Unit _unitTeam2;

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

        _unitTeam1 = _team1[currentUnitNumberOfPlayer1];
        _unitTeam2 = _team2[currentUnitNumberOfPlayer2];

        return [currentUnitNumberOfPlayer1, currentUnitNumberOfPlayer2];
    }

    private int AskAPlayerForTheChosenUnit(int playerNumber, UnitsList units)
    {
        if (playerNumber==0)
            return _window.SelectUnitTeam1();
        else
        {
            return _window.SelectUnitTeam2();
        }
    }

    public void ShowRoundInformation(int currentRound, string attackersName, int playersNumber)
    {
        // todo: tal vez esto no va aca pero ponerlo en algun lugar
        _window.UpdateUnitsStatsDuringBattle(_unitTeam1, _unitTeam2);
    }

    public void AnnounceAdvantage(Unit unitWithAdvantage, Unit unitWithoutAdvantage)
    {
    }

    public void AnnounceThereIsNoAdvantage()
    {
    }

    public void ShowAllSkills(Unit unit)
    {
    }

    public void AnnounceHpRecuperation(Unit unitThatRecuperatesHp, int amount, int finalHp)
    {
    }

    public void AnnounceDamageBeforeCombat(Unit unitThatReceivesDamage, int damage)
    {
    }

    public void AnnounceCurationAfterCombat(Unit unitThatReceivesCuration, int recuperatedAmount)
    {
    }

    public void AnnounceDamageAfterCombat(Unit unitThatReceivesDamage, int damage)
    {
        return;
    }

    public void ShowAttack(string attackersName, string defendersName, int damage)
    {
        // todo: pensar en como actualizarlo, los teams y los units
        // ojo, queda neggg el hp a veces

        if (attackersName == _unitTeam1.Name)
        {
            _unitTeam2.Hp -= damage;
            _window.UpdateUnitsStatsDuringBattle(_unitTeam1, _unitTeam2);
            _window.ShowAttackFromTeam1(_unitTeam1, _unitTeam2);
        }
        else
        {
            _unitTeam1.Hp -= damage;
            _window.UpdateUnitsStatsDuringBattle(_unitTeam1, _unitTeam2);
            _window.ShowAttackFromTeam2(_unitTeam1, _unitTeam2);
        }
    }

    public void AnnounceUnitCannotFollowUp(string name)
    {
        return;
    }

    public void AnnounceNoUnitCanFollowUp()
    {
        return;
    }

    public void ShowHp(Unit roundStarterUnit, Unit opponentsUnit)
    {
        // todo: teams no se actualizannn ojito, tal vez llamar a update teams desde controller
        _window.UpdateTeams(_team1, _team2);
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
    
    private static bool IsPlayer1TheCurrentAttacker(int currentAttacker)
    {
        return currentAttacker == IdOfPlayer1;
    }
    
}