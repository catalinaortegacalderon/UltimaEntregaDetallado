using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.SkillsThatAffectCombat;

public class QuickRiposteSkill: Skill
{
    public QuickRiposteSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new AndCondition([new MyHpIsBiggerThanCondition(0.6), new OpponentStartsCombatCondition()]);

        Effects = new Effect[1];
        Effects[0] = new GuaranteeFollowUpEffect();
    }
}