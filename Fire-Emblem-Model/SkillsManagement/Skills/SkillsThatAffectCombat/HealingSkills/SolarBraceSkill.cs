using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.SkillsThatAffectCombat.HealingSkills;

public class SolarBraceSkill: Skill
{
    public SolarBraceSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new MyUnitStartsCombatCondition();

        Effects = new Effect[1];
        Effects[0] = new HealingEffect(0.5);
    }
}