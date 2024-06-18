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
        return HasWeaponAdvantage(attackingWeapon, defensiveWeapon);
    }

    // todo: ver si hacer funcion con las 2 armas, son muchos casos
    // capaz un switch
    private bool HasWeaponAdvantage(WeaponType attackingWeaponType, WeaponType defensiveWeaponType)
    {
        var hasWeaponAdvantage = (attackingWeaponType == WeaponType.Sword) & (defensiveWeaponType == WeaponType.Axe) ||
                                 (attackingWeaponType == WeaponType.Lance) & (defensiveWeaponType == WeaponType.Sword) ||
                                 (attackingWeaponType == WeaponType.Axe) & (defensiveWeaponType == WeaponType.Lance);
        return hasWeaponAdvantage;
    }
}