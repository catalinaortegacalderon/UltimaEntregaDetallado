using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;

public class OpponentUsesCertainWeaponCondition : Condition
{
    private readonly Weapon[] _weapons;

    public OpponentUsesCertainWeaponCondition(Weapon[] weapons)
    {
        _weapons = weapons;
    }

    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        return _weapons.Contains(opponentsUnit.Weapon);
    }
}