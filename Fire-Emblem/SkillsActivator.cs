using ConsoleApp1.EncapsulatedLists;
using ConsoleApp1.GameDataStructures;

namespace Fire_Emblem;

public static class SkillsActivator
{
    public static void ActivateSkills(Unit attackingUnit, Unit defensiveUnit)
    {
        var conditionEffectPairs = GetAllConditionEffectPairs(attackingUnit, defensiveUnit);
        conditionEffectPairs.Prioritize();
        ApplyAllValidEffects(conditionEffectPairs);
    }

    private static ConditionEffectPairsList GetAllConditionEffectPairs(Unit attackingUnit, Unit defensiveUnit)
    {
        var conditionEffectPairs = new ConditionEffectPairsList();

        AddConditionEffectPairs(attackingUnit, defensiveUnit, conditionEffectPairs);
        AddConditionEffectPairs(defensiveUnit, attackingUnit, conditionEffectPairs);

        return conditionEffectPairs;
    }

    private static void AddConditionEffectPairs(Unit sourceUnit, Unit opponentsUnit, ConditionEffectPairsList list)
    {
        foreach (var skill in sourceUnit.Skills)
        {
            for (int i = 0; i < skill.GetConditionLength(); i++)
            {
                list.AddConditionEffectPair(new ConditionEffectPair(sourceUnit, 
                    opponentsUnit, skill, i));
            }
        }
    }

    private static void ApplyAllValidEffects(ConditionEffectPairsList prioritizedList)
    {
        foreach (var conditionEffectPair in prioritizedList)
        {
            if (IsConditionValid(conditionEffectPair))
                ApplyEffect(conditionEffectPair);
        }
    }
    
    private static bool IsConditionValid(ConditionEffectPair conditionEffectPair)
    {
        return conditionEffectPair.Condition.DoesItHold(conditionEffectPair.UnitThatHasThePair, 
            conditionEffectPair.OpponentsUnit);
    }

    private static void ApplyEffect(ConditionEffectPair conditionEffectPair)
    {
        conditionEffectPair.Effect.ApplyEffect(conditionEffectPair.UnitThatHasThePair, 
            conditionEffectPair.OpponentsUnit);
    }
    
}