using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class LifeAndDeathSkill : Skill
{
    public LifeAndDeathSkill()
    {
        Conditions = new Condition[4];
        Conditions[0] = new AlwaysTrueCondition();
        Conditions[1] = new AlwaysTrueCondition();
        Conditions[2] = new AlwaysTrueCondition();
        Conditions[3] = new AlwaysTrueCondition();

        Effects = new Effect[4];
        Effects[0] = new ChangeStatsInEffect(StatType.Atk, 6);
        Effects[1] = new ChangeStatsInEffect(StatType.Spd, 6);
        Effects[2] = new ChangeStatsInEffect(StatType.Def, -5);
        Effects[3] = new ChangeStatsInEffect(StatType.Res, -5);
    }
}