using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

public class OrCondition : Condition
{
    private readonly Condition[] _conditions;

    public OrCondition(Condition[] conditions)
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
            if (condition.DoesItHold(myUnit, opponentsUnit))
                return true;
        return false;
    }
}