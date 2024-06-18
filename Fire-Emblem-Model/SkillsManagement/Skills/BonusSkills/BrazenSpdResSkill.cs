using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class BrazenSpdResSkill : Skill
{
    public BrazenSpdResSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new MyHpIsLessThanCondition(0.8);
        Conditions[1] = new MyHpIsLessThanCondition(0.8);

        Effects = new Effect[2];
        Effects[0] = new ChangeStatsInEffect(StatType.Spd, 10);
        Effects[1] = new ChangeStatsInEffect(StatType.Res, 10);
    }
}