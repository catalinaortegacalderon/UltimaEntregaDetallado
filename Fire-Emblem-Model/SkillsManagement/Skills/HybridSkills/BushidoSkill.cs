using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class BushidoSkill : Skill
{
    public BushidoSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new AlwaysTrueCondition();
        Conditions[1] = new CompareTotalSpdCondition();
        Effects = new Effect[2];
        Effects[0] = new ExtraDamageEffect(7, DamageEffectCategory.All);
        Effects[1] = new PercentualDamageReductionDeterminedBySpdDifferenceEffect(
            4, 0.6, DamageEffectCategory.All);
    }
}