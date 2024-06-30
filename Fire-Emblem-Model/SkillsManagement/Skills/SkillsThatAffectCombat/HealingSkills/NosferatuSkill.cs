using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.SkillsThatAffectCombat.HealingSkills;

public class NosferatuSkill: Skill
{
    public NosferatuSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new MyUnitUsesCertainWeaponsCondition([WeaponType.Magic]);

        Effects = new Effect[1];
        Effects[0] = new HealingEffect(0.5);
    }
}