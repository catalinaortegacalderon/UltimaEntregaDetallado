using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class PrescienceSkill : Skill
{
    public PrescienceSkill()
    {
        Conditions = new Condition[3];
        Conditions[0] = new AlwaysTrueCondition();
        Conditions[1] = new AlwaysTrueCondition();
        Conditions[2] = new OrCondition([
            new MyUnitStartsCombatCondition(), new OpponentUsesCertainWeaponCondition([Weapon.Magic, Weapon.Bow])
        ]);
        Effects = new Effect[3];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Atk, -5);
        Effects[1] = new ChangeOpponentsStatsInEffect(StatType.Res, -5);
        Effects[2] = new PercentualDamageReductionEffect(0.7, DamageEffectCategory.FirstAttack);
    }
}