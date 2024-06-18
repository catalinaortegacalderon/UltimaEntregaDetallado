using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

public class AndCondition : Condition
{
    private readonly Condition[] _conditions;

    public AndCondition(Condition[] conditions)
    {
        this._conditions = conditions;
        this.Priority = GetMaxPriority(conditions);
    }

    private ConditionPriority GetMaxPriority(Condition[] conditions)
    {
        var maxPriority = ConditionPriority.PriorityOfBonusAndPenalties;
        foreach (var condition in conditions)
        {
            if (condition.GetPriority() > maxPriority)
            {
                maxPriority = condition.GetPriority();
            }
        }
        return maxPriority;
    }

    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        foreach (var condition in _conditions)
            if (condition.DoesItHold(myUnit, opponentsUnit) == false)
                return false;
        return true;
    }
}