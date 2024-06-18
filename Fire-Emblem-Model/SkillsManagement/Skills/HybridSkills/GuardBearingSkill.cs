using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class GuardBearingSkill : Skill
{
    public GuardBearingSkill()
    {
        Conditions = new Condition[3];
        Conditions[0] = new AlwaysTrueCondition();
        Conditions[1] = new AlwaysTrueCondition();
        Conditions[2] = new AlwaysTrueCondition();
        Effects = new Effect[3];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Spd, -4);
        Effects[1] = new ChangeOpponentsStatsInEffect(StatType.Def, -4);
        Effects[2] = new GuardBearingEffect();
    }
}