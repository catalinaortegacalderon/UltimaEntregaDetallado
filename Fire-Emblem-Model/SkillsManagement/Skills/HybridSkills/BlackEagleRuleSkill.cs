using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class BlackEagleRuleSkill : Skill
{
    public BlackEagleRuleSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new MyHpIsBiggerThanCondition(0.25);
        Conditions[1] = new AndCondition([
            new MyHpIsBiggerThanCondition(0.25),
            new OpponentStartsCombatCondition()
        ]);

        Effects = new Effect[2];
        Effects[0] = new GuaranteeFollowUpEffect();
        Effects[1] = new PercentualDamageReductionEffect(0.2, DamageEffectCategory.FollowUp);
    }
}