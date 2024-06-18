using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class FlowFeatherSkill : Skill
{
    public FlowFeatherSkill()
    {
        Conditions = new Condition[3];
        Conditions[0] = new MyUnitStartsCombatCondition();
        Conditions[1] = new AndCondition([new MyUnitStartsCombatCondition(), 
            new CompareTotalSpdAddingSpdToTheOpponent(-10)]);
        Conditions[1] = new AndCondition([new MyUnitStartsCombatCondition(), 
            new CompareTotalSpdAddingSpdToTheOpponent(-10)]);

        Effects = new Effect[3];
        Effects[0] = new NeutralizationOfFollowUpDenialEffect();
        // todo: voy aca
        //Effects[1] = new ExtraDamageEffect();
        //Effects[2] = new PercentualDamageReductionEffect();
    }
}