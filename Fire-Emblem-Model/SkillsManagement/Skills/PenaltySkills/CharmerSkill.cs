using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.PenaltySkills;

public class CharmerSkill : Skill
{
    public CharmerSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new MyCurrentOpponentIsAlsoTheLastOpponentCondition();
        Conditions[1] = new MyCurrentOpponentIsAlsoTheLastOpponentCondition();

        Effects = new Effect[2];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Atk, -3);
        Effects[1] = new ChangeOpponentsStatsInEffect(StatType.Spd, -3);
    }
}