using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class AegisShieldSkill : Skill
{
    public AegisShieldSkill()
    {
        Conditions = new Condition[3];
        Conditions[0] = new AlwaysTrueCondition();
        Conditions[1] = new AlwaysTrueCondition();
        Conditions[2] = new AlwaysTrueCondition();
        Effects = new Effect[3];
        Effects[0] = new ChangeStatsInEffect(StatType.Def, 6);
        Effects[1] = new ChangeStatsInEffect(StatType.Res, 3);
        Effects[2] = new PercentualDamageReductionEffect(0.5, DamageEffectCategory.FirstAttack);
    }
}