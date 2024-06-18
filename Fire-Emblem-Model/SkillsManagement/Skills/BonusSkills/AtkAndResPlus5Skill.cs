using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class AtkAndResPlus5Skill : Skill
{
    public AtkAndResPlus5Skill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new AlwaysTrueCondition();
        Conditions[1] = new AlwaysTrueCondition();

        Effects = new Effect[2];
        Effects[0] = new ChangeStatsInEffect(StatType.Atk, 5);
        Effects[1] = new ChangeStatsInEffect(StatType.Res, 5);
    }
}