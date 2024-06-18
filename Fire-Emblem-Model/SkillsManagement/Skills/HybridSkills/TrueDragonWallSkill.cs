using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class TrueDragonWallSkill : Skill
{
    public TrueDragonWallSkill()
    {
        Conditions = new Condition[3];
        Conditions[0] = new CompareTotalResCondition();
        Conditions[1] = new CompareTotalResCondition();
        Conditions[2] = new MyUnitHasAllyWithMagicCondition();

        Effects = new Effect[3];
        Effects[0] = new PercentualDamageReductionDeterminedByResDifferenceEffect(
             6, 0.4, DamageEffectCategory.FirstAttack);
        Effects[1] = new PercentualDamageReductionDeterminedByResDifferenceEffect(
            4, 0.6, DamageEffectCategory.FollowUp );
        Effects[2] = new HealingAtTheEndOfTheCombatEffect(7);
    }
    
}