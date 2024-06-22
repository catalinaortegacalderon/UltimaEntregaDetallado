using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class BlueLionRuleSkill : Skill
{
    public BlueLionRuleSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new CompareTotalStatCondition(StatType.Def);
        Conditions[1] = new OpponentStartsCombatCondition();

        Effects = new Effect[2];
        Effects[0] = new PercentageDamageReductionDeterminedByDefDifferenceEffect(4, 0.6, 
            DamageEffectCategory.All);
        Effects[1] = new GuaranteeFollowUpEffect();
    }
}