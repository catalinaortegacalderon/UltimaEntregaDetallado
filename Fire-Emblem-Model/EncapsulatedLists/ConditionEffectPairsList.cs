using System.Collections;
using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.EncapsulatedLists;

public class ConditionEffectPairsList : IEnumerable<ConditionEffectPair>
{
    private List<ConditionEffectPair> _conditionEffectPairs = [];

    public IEnumerator<ConditionEffectPair> GetEnumerator()
    {
        foreach (var conditionEffectPair in _conditionEffectPairs)
            yield return conditionEffectPair;
    }

    IEnumerator IEnumerable.GetEnumerator() 
        => _conditionEffectPairs.GetEnumerator();

    public void AddConditionEffectPair(ConditionEffectPair conditionEffectPair) 
        => _conditionEffectPairs.Add(conditionEffectPair);

    public void Prioritize()
    {
        _conditionEffectPairs = _conditionEffectPairs
            .OrderBy(pair => (int)pair.Condition.GetPriority())
            .ToList();
    }
    
}