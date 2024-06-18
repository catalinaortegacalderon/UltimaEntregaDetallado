using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class ChivalrySkill : Skill
{
    public ChivalrySkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new AndCondition([new MyUnitStartsCombatCondition(), new OpponentHasFullHpCondition()]);
        Conditions[1] = new AndCondition([new MyUnitStartsCombatCondition(), new OpponentHasFullHpCondition()]);
        Effects = new Effect[2];
        Effects[0] = new AbsolutDamageReductionEffect(2);
        Effects[1] = new ExtraDamageEffect(2, DamageEffectCategory.All);
    }
}