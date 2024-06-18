using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class DeadlyBladeSkill : Skill
{
    public DeadlyBladeSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new AndCondition([
            new MyUnitStartsCombatCondition(),
            new MyUnitUsesCertainWeaponsCondition([Weapon.Sword])
        ]);
        Conditions[1] = new AndCondition([
            new MyUnitStartsCombatCondition(),
            new MyUnitUsesCertainWeaponsCondition([Weapon.Sword])
        ]);

        Effects = new Effect[2];
        Effects[0] = new ChangeStatsInEffect(StatType.Atk, 8);
        Effects[1] = new ChangeStatsInEffect(StatType.Spd, 8);
    }
}