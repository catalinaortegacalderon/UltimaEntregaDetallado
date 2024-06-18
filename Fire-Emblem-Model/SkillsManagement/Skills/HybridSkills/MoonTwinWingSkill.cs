using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class MoonTwinWingSkill : Skill
{
    public MoonTwinWingSkill()
    {
        Conditions = new Condition[3];
        Conditions[0] = new MyHpIsBiggerThanCondition(0.25);
        Conditions[1] = new MyHpIsBiggerThanCondition(0.25);
        Conditions[2] = new AndCondition([
            new CompareTotalSpdCondition(),
            new MyHpIsBiggerThanCondition(0.25)
        ]);
        Conditions[2].ChangePriorityBecauseEffectPriorityIsBigger(ConditionPriority
            .PriorityOfConditionsThatRequireBonusAndPenaltiesInformation);

        Effects = new Effect[3];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Spd, -5);
        Effects[1] = new ChangeOpponentsStatsInEffect(StatType.Atk, -5);
        Effects[2] = new PercentualDamageReductionDeterminedBySpdDifferenceEffect(
            4, 0.6, DamageEffectCategory.All);
    }
}