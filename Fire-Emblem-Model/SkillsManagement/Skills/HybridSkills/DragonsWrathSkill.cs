using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class DragonsWrathSkill : Skill
{
    public DragonsWrathSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new AlwaysTrueCondition();
        Conditions[1] = new CompareMyAtkWithOpponentsResCondition();
        Effects = new Effect[2];
        Effects[0] = new PercentualDamageReductionEffect(0.75, DamageEffectCategory.FirstAttack);
        Effects[1] = new DragonsWrathSecondEffect();
    }
}