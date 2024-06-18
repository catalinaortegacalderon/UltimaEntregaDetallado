using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class EclipseBraceSkill : Skill
{
    public EclipseBraceSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new  AndCondition([ new MyUnitStartsCombatCondition(), 
            new MyUnitUsesCertainWeaponsCondition([Weapon.Axe,Weapon.Lance, Weapon.Bow, Weapon.Sword])]);
        Conditions[0].ChangePriorityBecauseEffectPriorityIsBigger(
            ConditionPriority.PriorityOfConditionsThatRequireBonusAndPenaltiesInformation);
        Conditions[1] = new MyUnitStartsCombatCondition();

        Effects = new Effect[2];
        Effects[0] = new ExtraDamageReductionConsideringOpponentsTotalStatPercentageEffect( 
            DamageEffectCategory.All ,StatType.Def, 0.3);
        Effects[1] = new HealingEffect(0.5);
    }
    
}