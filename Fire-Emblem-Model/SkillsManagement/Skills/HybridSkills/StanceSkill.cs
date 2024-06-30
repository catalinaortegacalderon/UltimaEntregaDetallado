using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;
public class StanceSkill : Skill
{
    public StanceSkill(StatType firstStat, StatType secondStat, int amount1, int amount2)
    {
        Conditions = new Condition[3];
        Conditions[0] = Conditions[1] = Conditions[2] 
            = new OpponentStartsCombatCondition();
        
        Effects = new Effect[3];
        Effects[0] = new ChangeStatsInEffect(firstStat, amount1);
        Effects[1] = new ChangeStatsInEffect(secondStat, amount2);
        Effects[2] = new PercentageDamageReductionEffect(0.9, DamageEffectCategory.FollowUp);
    }
}