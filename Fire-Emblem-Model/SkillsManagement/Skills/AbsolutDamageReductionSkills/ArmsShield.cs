using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.AbsolutDamageReductionSkills;

public class ArmsShield : Skill
{
    public ArmsShield()
    {
        Conditions = new Condition[1];
        Conditions[0] = new MyUnitHasWeaponAdvantageCondition();

        Effects = new Effect[1];
        Effects[0] = new AbsolutDamageReductionEffect(7);
    }
}