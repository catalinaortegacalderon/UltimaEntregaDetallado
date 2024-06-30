using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class HpPlus15Skill : Skill
{
    public HpPlus15Skill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new AlwaysTrueCondition();
        Effects = new Effect[1];
        Effects[0] = new ChangeHpInEffect(15);
    }
}