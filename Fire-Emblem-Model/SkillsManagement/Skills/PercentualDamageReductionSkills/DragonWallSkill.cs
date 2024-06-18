using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.PercentualDamageReductionSkills;

public class DragonWallSkill : Skill
{
    public DragonWallSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new CompareTotalResCondition();

        Effects = new Effect[1];
        Effects[0] = new PercentualDamageReductionDeterminedByResDifferenceEffect(
            4, 0.6, DamageEffectCategory.All);
    }
}