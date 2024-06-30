using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class BrazenSkill : Skill
{
    public BrazenSkill(StatType firstStat, StatType secondStat)
    {
        Conditions = new Condition[2];
        Conditions[0] = Conditions[1] = new MyHpIsLessThanCondition(0.8);

        Effects = new Effect[2];
        Effects[0] = new ChangeStatsInEffect(firstStat, 10);
        Effects[1] = new ChangeStatsInEffect(secondStat, 10);
    }
}