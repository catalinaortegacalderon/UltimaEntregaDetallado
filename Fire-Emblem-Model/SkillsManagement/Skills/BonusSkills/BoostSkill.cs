using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class BoostSkill : Skill
{
    public BoostSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new MyHpIsLessThanOpponentsHpPlusCondition(3);

        Effects = new Effect[1];
    }
}