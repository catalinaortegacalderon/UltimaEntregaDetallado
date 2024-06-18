using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.NeutralizationEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class SavyFighterSkill : Skill
{
    public SavyFighterSkill()
    {
        Conditions = new Condition[3];
        Conditions[0] = new OpponentStartsCombatCondition();
        Conditions[1] = new OpponentStartsCombatCondition();
        Conditions[2] = new AndCondition([
            new CompareTotalSpdAddingSpdToTheOpponent(-4),
            new OpponentStartsCombatCondition()
        ]);

        Effects = new Effect[3];
        Effects[0] = new OpponentDenialOfGuaranteedFollowUpEffect();
        Effects[1] = new NeutralizationOfFollowUpDenialEffect();
        Effects[2] = new PercentualDamageReductionEffect(0.7, 
            DamageEffectCategory.FirstAttack);
    }
}