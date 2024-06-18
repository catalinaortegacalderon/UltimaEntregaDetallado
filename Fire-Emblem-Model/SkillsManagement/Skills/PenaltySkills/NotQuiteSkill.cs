using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.PenaltySkills;

public class NotQuiteSkill : Skill
{
    public NotQuiteSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new OpponentStartsCombatCondition();

        Effects = new Effect[1];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Atk, -4);
    }
}