using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class SoulBladeSkill : Skill
{
    public SoulBladeSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new MyUnitUsesCertainWeaponsCondition([WeaponType.Sword]);

        Effects = new Effect[1];
        Effects[0] = new SoulBladeEffect();
    }
}