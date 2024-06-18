using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;

public class MyUnitUsesCertainWeaponsCondition : Condition
{
    private readonly WeaponType[] _usedWeapon;

    public MyUnitUsesCertainWeaponsCondition(WeaponType[] weapon)
    {
        _usedWeapon = weapon;
    }

    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        return _usedWeapon.Contains(myUnit.WeaponType);
    }
}