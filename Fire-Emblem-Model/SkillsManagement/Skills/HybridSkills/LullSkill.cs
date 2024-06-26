using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.NeutralizationEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class LullSkill : Skill
{
    public LullSkill(StatType firstStat, StatType secondStat)
    {
        Conditions = new Condition[4];
        Conditions[0] = Conditions[1] = Conditions[2] = Conditions[3] = new AlwaysTrueCondition();

        Effects = new Effect[4];
        Effects[0] = new ChangeOpponentsStatsInEffect(firstStat, -3);
        Effects[1] = new ChangeOpponentsStatsInEffect(secondStat, -3);
        Effects[2] = new NeutralizeOneOfOpponentsBonusEffect(firstStat);
        Effects[3] = new NeutralizeOneOfOpponentsBonusEffect(secondStat);
    }
}