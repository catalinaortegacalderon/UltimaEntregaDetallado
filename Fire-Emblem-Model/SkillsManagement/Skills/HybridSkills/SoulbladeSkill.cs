using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class SoulbladeSkill : Skill
{
    public SoulbladeSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new MyUnitUsesCertainWeaponsCondition([Weapon.Sword]);

        Effects = new Effect[1];
        Effects[0] = new SoulbladeEffect();
    }
}