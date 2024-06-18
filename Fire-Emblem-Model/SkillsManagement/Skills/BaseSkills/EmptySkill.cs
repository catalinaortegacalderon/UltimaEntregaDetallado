using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.BaseSkills;

public class EmptySkill : Skill
{
    public EmptySkill()
    {
        Conditions = new Condition[] { new AlwaysTrueCondition() };

        Effects = new Effect[] { new EmptyEffect() };
    }
}