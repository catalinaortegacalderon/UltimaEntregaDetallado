using System.Collections;
using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.EncapsulatedLists;

public class PlayersList : IEnumerable<Player>
{
    private readonly List<Player> _players = [];

    public IEnumerator<Player> GetEnumerator()
    {
        foreach (var skill in _players) yield return skill;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _players.GetEnumerator();
    }

    public Player GetPlayerById(int index)
    {
        return _players[index];
    }

    public void AddPlayer(Player player)
    {
        _players.Add(player);
    }
}