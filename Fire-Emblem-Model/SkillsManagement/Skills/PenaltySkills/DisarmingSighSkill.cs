using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.PenaltySkills;

public class DisarmingSighSkill : Skill
{
    public DisarmingSighSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new OpponentIsAManCondition();

        Effects = new Effect[1];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Atk, -8);
    }
}