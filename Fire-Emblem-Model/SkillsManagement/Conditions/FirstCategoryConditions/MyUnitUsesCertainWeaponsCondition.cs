using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;

public class MyUnitUsesCertainWeaponsCondition : Condition
{
    private readonly Weapon[] _usedWeapon;

    public MyUnitUsesCertainWeaponsCondition(Weapon[] weapon)
    {
        _usedWeapon = weapon;
    }

    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        return _usedWeapon.Contains(myUnit.Weapon);
    }
}