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
    public void AnnounceDamageBeforeCombat(Unit unitThatRecievesDamage, int damage);
    public void AnnounceCurationAfterCombat(Unit unitThatRecievesCuration, int recuperatedAmount);
    public void AnnounceDamageAfterCombat(Unit unitThatRecievesDamage, int damage);
    public void ShowAttack(string attackersName, string defensorsName, int damage);
    public void AnnounceASpecificUnitCantDoAFollowup(String name);
    public void AnnounceNoUnitCanDoAFollowup();
    public void ShowHp(Unit roundStarterUnit, Unit opponentsUnit);
    public void AnnounceWinner(int winnersNumber);
}