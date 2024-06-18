using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class AgilitySkill : Skill
{
    public AgilitySkill(WeaponType weaponType)
    {
        Conditions = new Condition[2];
        Conditions[0] = new MyUnitUsesCertainWeaponsCondition([weaponType]);
        Conditions[1] = new MyUnitUsesCertainWeaponsCondition([weaponType]);

        Effects = new Effect[2];
        Effects[0] = new ChangeStatsInEffect(StatType.Spd, 12);
        Effects[1] = new ChangeStatsInEffect(StatType.Atk, -6);
    }
}