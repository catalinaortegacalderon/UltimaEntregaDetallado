using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;

public class ChaosStyleCondition : Condition
{
    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        if (myUnit.IsAttacking)
        {
            return DoesMagicAttackPhysicalWeapon(myUnit.WeaponType, 
                       opponentsUnit.WeaponType) 
                   || DoesMagicAttackPhysicalWeapon(opponentsUnit.WeaponType, 
                       myUnit.WeaponType);
        }
        return false;
    }

    private static bool DoesMagicAttackPhysicalWeapon(WeaponType attackingWeapon, WeaponType defensiveWeapon)
    {
        return attackingWeapon == WeaponType.Magic && IsWeaponPhysical(defensiveWeapon);
    }

    private static bool IsWeaponPhysical(WeaponType weapon)
    {
        return weapon is WeaponType.Bow or WeaponType.Axe or WeaponType.Sword or WeaponType.Lance;
    }
}