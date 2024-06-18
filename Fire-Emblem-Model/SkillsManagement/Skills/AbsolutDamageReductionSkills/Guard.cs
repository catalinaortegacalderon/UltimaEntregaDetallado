using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.AbsolutDamageReductionSkills;

public class Guard : Skill
{
    public Guard(Weapon weapon)
    {
        Conditions = new Condition[1];
        Conditions[0] = new OpponentUsesCertainWeaponCondition([weapon]);

        Effects = new Effect[1];
        Effects[0] = new AbsolutDamageReductionEffect(5);
    }
}