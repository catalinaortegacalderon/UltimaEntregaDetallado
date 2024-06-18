using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.PercentualDamageReductionSkills;

public class DodgeSkill : Skill
{
    public DodgeSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new CompareTotalSpdCondition();

        Effects = new Effect[1];
        Effects[0] = new PercentualDamageReductionDeterminedBySpdDifferenceEffect(4, 0.6, DamageEffectCategory.All);
    }
}