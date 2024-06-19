using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class NewDivinitySkill : Skill
{
    public NewDivinitySkill()
    {
        Conditions = new Condition[4];
        Conditions[0] = new MyHpIsBiggerThanCondition(0.25);
        Conditions[1] = new MyHpIsBiggerThanCondition(0.25);
        Conditions[2] = new AndCondition([
            new MyHpIsBiggerThanCondition(0.25),
            new CompareTotalStatCondition(StatType.Res)]);
        Conditions[3] = new MyHpIsBiggerThanCondition(0.4);

        Effects = new Effect[4];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Atk, -5);
        Effects[1] = new ChangeOpponentsStatsInEffect(StatType.Res, -5);
        Effects[2] = new PercentualDamageReductionDeterminedByResDifferenceEffect(4, 0.6,
            DamageEffectCategory.All);
        Effects[3] = new OpponentFollowUpDenialEffect();
    }
}