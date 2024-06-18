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
            if (myUnit.Weapon == Weapon.Magic && (opponentsUnit.Weapon == Weapon.Bow ||
                                                  opponentsUnit.Weapon == Weapon.Axe ||
                                                  opponentsUnit.Weapon == Weapon.Sword ||
                                                  opponentsUnit.Weapon == Weapon.Lance)) return true;
            if (opponentsUnit.Weapon == Weapon.Magic && (myUnit.Weapon == Weapon.Bow || myUnit.Weapon == Weapon.Axe ||
                                                         myUnit.Weapon == Weapon.Sword ||
                                                         myUnit.Weapon == Weapon.Lance)) return true;
        }

        return false;
    }
}