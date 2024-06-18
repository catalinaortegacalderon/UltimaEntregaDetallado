using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class ArmoredBlowSkill : Skill
{
    public ArmoredBlowSkill()
    {
        Conditions = new Condition[] { new MyUnitStartsCombatCondition() };

        Effects = new Effect[] { new ChangeStatsInEffect(StatType.Def, 8) };
    }
}