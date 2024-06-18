using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.SkillsThatAffectCombat;

public class FollowUpRingSkill: Skill
{
    public FollowUpRingSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new MyHpIsBiggerThanCondition(0.5);

        Effects = new Effect[1];
        Effects[0] = new GuaranteeFollowUpEffect();
    }
}