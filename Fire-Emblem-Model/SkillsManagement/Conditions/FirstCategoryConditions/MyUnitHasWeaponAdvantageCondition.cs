using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;

public class MyUnitHasWeaponAdvantageCondition : Condition
{
    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        var attackingWeapon = myUnit.Weapon;
        var defensiveWeapon = opponentsUnit.Weapon;
        return HasWeaponAdvantage(attackingWeapon, defensiveWeapon);
    }

    // todo: ver si hacer funcion con las 2 armas, son muchos casos
    // capaz un switch
    private bool HasWeaponAdvantage(Weapon attackingWeapon, Weapon defensiveWeapon)
    {
        var hasWeaponAdvantage = (attackingWeapon == Weapon.Sword) & (defensiveWeapon == Weapon.Axe) ||
                                 (attackingWeapon == Weapon.Lance) & (defensiveWeapon == Weapon.Sword) ||
                                 (attackingWeapon == Weapon.Axe) & (defensiveWeapon == Weapon.Lance);
        return hasWeaponAdvantage;
    }
}