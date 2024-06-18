using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class PowerSkill : Skill
{
    public PowerSkill(Weapon weapon)
    {
        Conditions = new Condition[2];
        Conditions[0] = new MyUnitUsesCertainWeaponsCondition([weapon]);
        Conditions[1] = new MyUnitUsesCertainWeaponsCondition([weapon]);

        Effects = new Effect[2];
        Effects[0] = new ChangeStatsInEffect(StatType.Atk, 10);
        Effects[1] = new ChangeStatsInEffect(StatType.Def, -10);
    }
}