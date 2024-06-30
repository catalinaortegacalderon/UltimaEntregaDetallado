using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;

namespace ConsoleApp1.SkillsManagement.Skills.SkillsThatAffectCombat.FollowUpDenialSkills;

public class WaryFighterSkill : Skill
{
    public WaryFighterSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new MyHpIsBiggerThanCondition(0.5);
        Conditions[1] = new MyHpIsBiggerThanCondition(0.5);

        Effects = new Effect[2];
        Effects[0] = new OpponentFollowUpDenialEffect();
        Effects[1] = new FollowUpDenialEffect();
    }
}