using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class DartingBlowSkill : Skill
{
    public DartingBlowSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new MyUnitStartsCombatCondition();

        Effects = new Effect[1];
        Effects[0] = new ChangeStatsInEffect(StatType.Spd, 8);
    }
}