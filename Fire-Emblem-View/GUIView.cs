using ConsoleApp1.EncapsulatedLists;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem_GUI;
using IUnit = ConsoleApp1.GameDataStructures.IUnit;

namespace Fire_Emblem_View;

public class GuiView : IView
{
    private readonly FireEmblemWindow _window;
    
    private const int IdOfPlayer1 = 0;
    private const int IdOfPlayer2 = 1;

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
        _window.ShowInvalidTeamMessage();
    }

    public void UpdateTeams(Player player1, Player player2)
    {
        IUnit[] team1 = new IUnit[player1.AmountOfUnits];
        IUnit[] team2 = new IUnit[player2.AmountOfUnits];
        
        Console.WriteLine(player1.AmountOfUnits);
        Console.WriteLine(player2.AmountOfUnits);
        
        for (int i = 0; i < player1.AmountOfUnits; i++)
            team1[i] = player1.Units.GetUnitByIndex(i);
        
        for (int i = 0; i < player2.AmountOfUnits; i++)
            team2[i] = player2.Units.GetUnitByIndex(i);
        
        _window.UpdateTeams(team1 as Fire_Emblem_GUI.IUnit[], 
            team2 as Fire_Emblem_GUI.IUnit[]);
    }

    public int[] AskBothPlayersForTheChosenUnit(PlayersList players, int currentAttacker)
    {
        throw new NotImplementedException();
    }

    public int AskAPlayerForTheChosenUnit(int playerNumber, UnitsList units)
    {
        throw new NotImplementedException();
    }

    public void ShowRoundInformation(int currentRound, string attackersName, int playersNumber)
    {
        throw new NotImplementedException();
    }

    public void AnnounceAdvantage(Unit unitWithAdvantage, Unit unitWithoutAdvantage)
    {
        throw new NotImplementedException();
    }

    public void AnnounceThereIsNoAdvantage()
    {
        throw new NotImplementedException();
    }

    public void ShowAllSkills(Unit unit)
    {
        throw new NotImplementedException();
    }

    public void AnnounceHpRecuperation(Unit unitThatRecuperatesHp, int amount, int finalHp)
    {
        throw new NotImplementedException();
    }

    public void AnnounceDamageBeforeCombat(Unit unitThatRecievesDamage, int damage)
    {
        throw new NotImplementedException();
    }

    public void AnnounceCurationAfterCombat(Unit unitThatRecievesCuration, int recuperatedAmount)
    {
        throw new NotImplementedException();
    }

    public void AnnounceDamageAfterCombat(Unit unitThatRecievesDamage, int damage)
    {
        throw new NotImplementedException();
    }

    public void ShowAttack(string attackersName, string defensorsName, int damage)
    {
        throw new NotImplementedException();
    }

    public void AnnounceASpecificUnitCantDoAFollowup(string name)
    {
        throw new NotImplementedException();
    }

    public void AnnounceNoUnitCanDoAFollowup()
    {
        throw new NotImplementedException();
    }

    public void ShowHp(Unit roundStarterUnit, Unit opponentsUnit)
    {
        throw new NotImplementedException();
    }

    public void AnnounceWinner(int winnersNumber)
    {
        throw new NotImplementedException();
    }
}