using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class MagNullFollowSkill : Skill
{
    public MagNullFollowSkill()
    {
        Conditions = new Condition[5];
        Conditions[0] = new AlwaysTrueCondition();
        Conditions[1] = new AlwaysTrueCondition();
        Conditions[2] = new AlwaysTrueCondition();
        Conditions[3] = new AlwaysTrueCondition();
        Conditions[4] = new AlwaysTrueCondition();
        Conditions[4].ChangePriorityBecauseEffectPriorityIsBigger(
            ConditionPriority.PriorityOfConditionsThatRequireDamageReductionInformation);

        Effects = new Effect[5];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Spd, -4);
        Effects[1] = new ChangeOpponentsStatsInEffect(StatType.Res, -4);
        Effects[2] = new NeutralizationOfFollowUpDenialEffect();
        Effects[3] = new OpponentDenialOfGuaranteedFollowUpEffect();
        Effects[4] = new ReductionOfPercentageDamageReductionToHalfEffect();
    }
}