using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class ScendscaleSkill : Skill
{
    public ScendscaleSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new AlwaysTrueCondition();
        Conditions[1] = new AlwaysTrueCondition();

        Effects = new Effect[2];

        Effects[0] = new ExtraDamageReductionConsideringMyTotalStatPercentageEffect(DamageEffectCategory.All,
            StatType.Atk, 0.25);
        Effects[1] = new DamageAtTheEndOfTheCombatIfUnitAttacksEffect(7);
    }
}