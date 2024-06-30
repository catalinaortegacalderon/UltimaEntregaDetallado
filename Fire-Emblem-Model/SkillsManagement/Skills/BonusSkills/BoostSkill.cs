using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class BoostSkill : Skill
{
    protected BoostSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new MyHpIsLessThanOpponentsHpPlusCondition(3);

        Effects = new Effect[1];
    }
}