using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.NeutralizationEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class WilyFighterSkill : Skill
{
    public WilyFighterSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = Conditions[1] = new AndCondition([
            new MyHpIsBiggerThanCondition(0.25),
            new OpponentStartsCombatCondition()
        ]);

        Effects = new Effect[2];
        Effects[0] = new NeutralizeOpponentsBonusEffect();
        Effects[1] = new GuaranteeFollowUpEffect();
    }
}