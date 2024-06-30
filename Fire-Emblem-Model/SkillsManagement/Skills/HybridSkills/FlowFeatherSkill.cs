using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class FlowFeatherSkill : Skill
{
    public FlowFeatherSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new MyUnitStartsCombatCondition();
        Conditions[1] = Conditions[1] = new AndCondition([new MyUnitStartsCombatCondition(), 
            new CompareTotalSpdAddingSpdToTheOpponent(-10)]);

        Effects = new Effect[2];
        Effects[0] = new NeutralizationOfFollowUpDenialEffect();
        Effects[1] = new FlowEffect(StatType.Res);
    }
}