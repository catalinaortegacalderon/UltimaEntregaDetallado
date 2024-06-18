using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class BreakerSkill : Skill
{
    public BreakerSkill(Weapon[] weapons)
    {
        Conditions = new Condition[2];
        Conditions[0] = new AndCondition([new MyHpIsBiggerThanCondition(0.5), 
            new OpponentUsesCertainWeaponCondition(weapons)]);
        Conditions[1] = new AndCondition([new MyHpIsBiggerThanCondition(0.5), 
            new OpponentUsesCertainWeaponCondition(weapons)]);
        
        Effects = new Effect[2];
        Effects[0] = new GuaranteeFollowUpEffect();
        Effects[1] = new OpponentFollowUpDenialEffect();
    }
}