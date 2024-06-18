using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;

public class OpponentIsAManCondition : Condition
{
    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        return opponentsUnit.Gender == Gender.Male;
    }
}