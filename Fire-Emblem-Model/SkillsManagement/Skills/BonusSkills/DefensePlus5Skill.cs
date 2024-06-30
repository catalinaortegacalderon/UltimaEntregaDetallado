using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class DefensePlus5Skill : Skill
{
    public DefensePlus5Skill()
    {
        Conditions = new Condition[] { new AlwaysTrueCondition() };

        Effects = new Effect[] { new ChangeStatsInEffect(StatType.Def, 5) };
    }
}