using ConsoleApp1.EncapsulatedLists;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem_GUI;

namespace Fire_Emblem_View.GuiLib;

public class GUIView : IView
{
    private FireEmblemWindow window;
    private const int IdOfPlayer1 = 0;
    private const int IdOfPlayer2 = 1;

    public GUIView(FireEmblemWindow window)
    {
        this.window = window;
    }
    
    public int AskPlayerForTheChosenFile(string[] files)
    {
        throw new NotImplementedException();
    }

    public void AnnounceTeamsAreNotValid()
    {
        throw new NotImplementedException();
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