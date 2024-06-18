using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1;

public class BindingShieldSkill : Skill
{
    public BindingShieldSkill()
    {
        Conditions = new Condition[3];
        Conditions[0] = new CompareTotalSpdAddingSpdToTheOpponent(5);
        Conditions[1] = new CompareTotalSpdAddingSpdToTheOpponent(5);
        Conditions[2] = new AndCondition([
            new MyUnitStartsCombatCondition(),
            new CompareTotalSpdAddingSpdToTheOpponent(5)
        ]);

        Effects = new Effect[3];
        Effects[0] = new GuaranteeFollowUpEffect();
        Effects[1] = new OpponentFollowUpDenialEffect();
        Effects[2] = new CounterAttackDenialOnOpponentEffect();
    }
}

