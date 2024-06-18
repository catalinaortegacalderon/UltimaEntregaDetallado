using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.PercentualDamageReductionSkills;

public class GoldenLotusSkill : Skill
{
    public GoldenLotusSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new OpponentUsesCertainWeaponCondition([
            Weapon.Sword, Weapon.Axe, Weapon.Lance,
            Weapon.Bow
        ]);

        Effects = new Effect[1];
        Effects[0] = new PercentualDamageReductionEffect(0.5, DamageEffectCategory.FirstAttack);
    }
}