using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;

namespace ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;

public class ChaosStyleCondition : Condition
{
    public override bool DoesItHold(Unit myUnit, Unit opponentsUnit)
    {
        // todo: hacer funion que revisa las armas, isphysical ismagic

        if (myUnit.IsAttacking)
        {
            if (myUnit.WeaponType == WeaponType.Magic && (opponentsUnit.WeaponType == WeaponType.Bow ||
                                                  opponentsUnit.WeaponType == WeaponType.Axe ||
                                                  opponentsUnit.WeaponType == WeaponType.Sword ||
                                                  opponentsUnit.WeaponType == WeaponType.Lance)) return true;
            if (opponentsUnit.WeaponType == WeaponType.Magic && (myUnit.WeaponType == WeaponType.Bow || myUnit.WeaponType == WeaponType.Axe ||
                                                         myUnit.WeaponType == WeaponType.Sword ||
                                                         myUnit.WeaponType == WeaponType.Lance)) return true;
        }

        return false;
    }
}