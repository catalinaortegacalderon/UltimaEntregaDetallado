using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class PoeticJusticeSkill : Skill
{
    public PoeticJusticeSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new AlwaysTrueCondition();
        Conditions[1] = new AlwaysTrueCondition();
        Conditions[1].ChangePriorityBecauseEffectPriorityIsBigger(ConditionPriority
            .PriorityOfConditionsThatRequireBonusAndPenaltiesInformation);

        Effects = new Effect[2];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Spd, -4);
        Effects[1] = new ExtraDamageReductionConsideringOpponentsTotalStatPercentageEffect(
            DamageEffectCategory.All, StatType.Atk, 0.15);
    }
}