using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class PerceptiveSkill : Skill
{
    public PerceptiveSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new MyUnitStartsCombatCondition();

        Effects = new Effect[1];
        Effects[0] = new ChangeStatsInBasePlusOnePointForEveryEffect(StatType.Spd, 12, 4);
    }
}