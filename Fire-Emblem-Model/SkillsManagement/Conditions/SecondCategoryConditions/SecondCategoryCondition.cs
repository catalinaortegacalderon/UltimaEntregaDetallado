using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;

public class SecondCategoryCondition : Condition
{
    protected SecondCategoryCondition()
    {
        Priority = ConditionPriority.PriorityOfConditionsThatRequireBonusAndPenaltiesInformation;
    }

    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        return true;
    }
}