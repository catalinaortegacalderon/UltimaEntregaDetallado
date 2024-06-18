using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.NeutralizationEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class SlickFighterSkill : Skill
{
    public SlickFighterSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new AndCondition([
            new MyHpIsBiggerThanCondition(0.25),
            new OpponentStartsCombatCondition()
        ]);
        Conditions[1] = new AndCondition([
            new MyHpIsBiggerThanCondition(0.25),
            new OpponentStartsCombatCondition()
        ]);

        Effects = new Effect[2];
        Effects[0] = new NeutralizePenaltiesEffect();
        Effects[1] = new GuaranteeFollowUpEffect();
    }
}