using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.ExtraDamageSkills;

public class BackAtYouSkill : Skill
{
    public BackAtYouSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new OpponentStartsCombatCondition();

        Effects = new Effect[1];
        Effects[0] = new BackAtYouEffect();
    }
}