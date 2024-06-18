using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;

public class OpponentStartsCombatCondition : Condition
{
    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        return myUnit.IsAttacking == false;
    }
}