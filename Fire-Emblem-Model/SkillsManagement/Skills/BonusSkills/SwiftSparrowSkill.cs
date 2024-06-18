using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class SwiftSparrowSkill : Skill
{
    public SwiftSparrowSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new MyUnitStartsCombatCondition();
        Conditions[1] = new MyUnitStartsCombatCondition();

        Effects = new Effect[2];
        Effects[0] = new ChangeStatsInEffect(StatType.Atk, 6);
        Effects[1] = new ChangeStatsInEffect(StatType.Spd, 6);
    }
}