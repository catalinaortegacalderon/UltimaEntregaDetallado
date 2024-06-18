using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class ResolveSkill : Skill
{
    public ResolveSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new MyHpIsLessThanCondition(0.75);
        Conditions[1] = new MyHpIsLessThanCondition(0.75);
        Effects = new Effect[2];
        Effects[0] = new ChangeStatsInEffect(StatType.Def, 7);
        Effects[1] = new ChangeStatsInEffect(StatType.Res, 7);
    }
}