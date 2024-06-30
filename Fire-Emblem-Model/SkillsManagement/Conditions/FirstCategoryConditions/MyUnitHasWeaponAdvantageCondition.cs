using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;

public class MyUnitHasWeaponAdvantageCondition : Condition
{
    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        var attackingWeapon = myUnit.WeaponType;
        var defensiveWeapon = opponentsUnit.WeaponType;
        return DamageCalculator.HasAttackerAdvantage(attackingWeapon, defensiveWeapon);
    }
}