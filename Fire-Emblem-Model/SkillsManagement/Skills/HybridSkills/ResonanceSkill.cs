using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class ResonanceSkill : Skill
{
    public ResonanceSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new AndCondition([
            new MyUnitUsesCertainWeaponsCondition([Weapon.Magic]),
            new MyHpIsBiggerThanConstantCondition(2)]);
        Conditions[1] = new AndCondition([
            new MyUnitUsesCertainWeaponsCondition([Weapon.Magic]),
            new MyHpIsBiggerThanConstantCondition(2)]);

        Effects = new Effect[2];
        Effects[0] = new DamageAtTheBeginningOfTheCombatEffect(1);
        Effects[1] = new ExtraDamageEffect(3, DamageEffectCategory.All);

    }
}