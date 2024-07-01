using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.PercentageDamageReductionSkills;

public class DodgeSkill : Skill
{
    public DodgeSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new CompareTotalStatCondition(StatType.Spd);

        Effects = new Effect[1];
        Effects[0] = new PercentageDamageReductionDeterminedBySpdDifferenceEffect(4, 0.6, 
            DamageEffectCategory.All);
    }
}