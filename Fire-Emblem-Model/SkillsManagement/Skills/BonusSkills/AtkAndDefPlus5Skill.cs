using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class AtkAndDefPlus5Skill : Skill
{
    public AtkAndDefPlus5Skill()
    {
        Conditions = new Condition[2];
        Conditions[0] = Conditions[1] = new AlwaysTrueCondition();

        Effects = new Effect[2];
        Effects[0] = new ChangeStatsInEffect(StatType.Atk, 5);
        Effects[1] = new ChangeStatsInEffect(StatType.Def, 5);
    }
}