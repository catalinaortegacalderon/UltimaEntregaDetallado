using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;

public class OpponentUsesCertainWeaponCondition : Condition
{
    private readonly WeaponType[] _weapons;

    public OpponentUsesCertainWeaponCondition(WeaponType[] weapons)
    {
        _weapons = weapons;
    }

    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        return _weapons.Contains(opponentsUnit.WeaponType);
    }
}