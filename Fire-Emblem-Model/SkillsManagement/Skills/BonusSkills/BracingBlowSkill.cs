using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class BracingBlowSkill : Skill
{
    public BracingBlowSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new MyUnitStartsCombatCondition();
        Conditions[1] = new MyUnitStartsCombatCondition();

        Effects = new Effect[2];
        Effects[0] = new ChangeStatsInEffect(StatType.Def, 6);
        Effects[1] = new ChangeStatsInEffect(StatType.Res, 6);
    }
}