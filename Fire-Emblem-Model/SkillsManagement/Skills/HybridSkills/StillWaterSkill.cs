using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class StillWaterSkill : Skill
{
    public StillWaterSkill()
    {
        Conditions = new Condition[3];
        Conditions[0] = new AlwaysTrueCondition();
        Conditions[1] = new AlwaysTrueCondition();
        Conditions[2] = new AlwaysTrueCondition();

        Effects = new Effect[3];
        Effects[0] = new ChangeStatsInEffect(StatType.Atk, 6);
        Effects[1] = new ChangeStatsInEffect(StatType.Res, 6);
        Effects[2] = new ChangeStatsInEffect(StatType.Def, -5);
    }
}