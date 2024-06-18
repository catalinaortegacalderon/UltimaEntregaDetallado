using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class FlightSkill : Skill
{
    public FlightSkill(StatType referenceStat)
    {
        Conditions = new Condition[5];
        Conditions[0] = new AlwaysTrueCondition();
        Conditions[1] = new AlwaysTrueCondition();
        Conditions[2] = new CompareBaseStatsMinusAmountCondition(StatType.Spd, 10);
        Conditions[3] = new CompareBaseStatsMinusAmountCondition(StatType.Spd, 10);
        Conditions[4] = new AndCondition([
            new FlightSkillCondition(referenceStat),
            new CompareBaseStatsMinusAmountCondition(StatType.Spd, 10)
        ]);
        

        Effects = new Effect[5];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Atk, -4);
        Effects[1] = new ChangeOpponentsStatsInEffect(StatType.Def, -4);
        Effects[2] = new ChangeOpponentsStatsInBaseStatDifferencePercentageEffect(StatType.Def, 0.8,
            referenceStat);
        Effects[3] = new ChangeOpponentsStatsInBaseStatDifferencePercentageEffect(StatType.Atk, 0.8,
            referenceStat);
        Effects[4] = new OpponentFollowUpDenialEffect();
    }
}