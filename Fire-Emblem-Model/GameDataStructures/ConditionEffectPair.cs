using System.Collections;
using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.GameDataStructures;

public class ConditionEffectPair : IEnumerable
{
    public readonly Condition Condition;
    public readonly Effect Effect;
    public readonly Unit OpponentsUnit;
    public readonly Unit UnitThatHasThePair;

    public ConditionEffectPair(Unit unitThatHasThePair, Unit opponentsUnit, Skill skill, int pairIndex)
    {
        UnitThatHasThePair = unitThatHasThePair;
        OpponentsUnit = opponentsUnit;
        Condition = skill.GetCondition(pairIndex);
        Effect = skill.GetEffect(pairIndex);
        ManageDivineRecreationsOrBrashAssaultSpecialCase();
    }

    private void ManageDivineRecreationsOrBrashAssaultSpecialCase()
    {
        // todo: encapsular
        if ((Effect is DivineRecreationEffect || Effect is BrashAssaultEffect)
            && UnitThatHasThePair.StartedTheRound)
            Condition.ChangePriorityBecauseEffectPriorityIsBigger(ConditionPriority
                .PriorityOfDivineRecreationWhenUnitBeginsCombat);
        if ((Effect is DivineRecreationEffect || Effect is BrashAssaultEffect)
            && OpponentsUnit.StartedTheRound)
            Condition.ChangePriorityBecauseEffectPriorityIsBigger(ConditionPriority
                .PriorityOfDivineRecreationWhenOpponentBeginsCombat);
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}