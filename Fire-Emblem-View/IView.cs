using ConsoleApp1.EncapsulatedLists;
using ConsoleApp1.GameDataStructures;

namespace Fire_Emblem_View;

public interface IView
{
    public int AskPlayerForTheChosenFile(string[] files);
    public void AnnounceTeamsAreNotValid();
    public void UpdateTeams(Player player1, Player player2);
    public int[] AskBothPlayersForTheChosenUnit(PlayersList players, int currentAttacker);
    public void ShowRoundInformation(int currentRound, string attackersName, int playersNumber);
    public void AnnounceAdvantage(Unit unitWithAdvantage, Unit unitWithoutAdvantage);
    public void AnnounceThereIsNoAdvantage();
    public void ShowAllSkills(Unit unit);
    public void AnnounceHpRecuperation(Unit unitThatRecuperatesHp, int amount, int finalHp);
    public void AnnounceDamageBeforeCombat(Unit unitThatReceivesDamage, int damage);
    public void AnnounceCurationAfterCombat(Unit unitThatReceivesCuration, int recuperatedAmount);
    public void AnnounceDamageAfterCombat(Unit unitThatReceivesDamage, int damage);
    public void ShowAttack(string attackersName, string defendersName, int damage);
    public void AnnounceUnitCannotFollowUp(String name);
    public void AnnounceNoUnitCanFollowUp();
    public void ShowHp(Unit roundStarterUnit, Unit opponentsUnit);
    public void AnnounceWinner(int winnersNumber);
}