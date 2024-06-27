using System.Collections;
using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.GameDataStructures;

public class ConditionEffectPair
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
        if (IsSpecialCaseAndCertainUnitStartsRound(UnitThatHasThePair))
            Condition.ChangePriorityBecauseEffectPriorityIsBigger(ConditionPriority
                .PriorityOfDivineRecreationWhenUnitBeginsCombat);
        if (IsSpecialCaseAndCertainUnitStartsRound(OpponentsUnit))
            Condition.ChangePriorityBecauseEffectPriorityIsBigger(ConditionPriority
                .PriorityOfDivineRecreationWhenOpponentBeginsCombat);
    }

    private bool IsSpecialCaseAndCertainUnitStartsRound(Unit unit)
    {
        return Effect is DivineRecreationEffect or BrashAssaultEffect
               && unit.StartedTheRound;
    }
}