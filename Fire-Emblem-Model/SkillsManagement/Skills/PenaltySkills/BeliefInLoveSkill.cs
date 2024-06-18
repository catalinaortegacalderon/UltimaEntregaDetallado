using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.PenaltySkills;

public class BeliefInLoveSkill : Skill
{
    public BeliefInLoveSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = new OrCondition([
            new OpponentHasFullHpCondition(),
            new OpponentStartsCombatCondition()
        ]);
        Conditions[1] = new OrCondition([
            new OpponentHasFullHpCondition(),
            new OpponentStartsCombatCondition()
        ]);

        Effects = new Effect[2];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Atk, -5);
        Effects[1] = new ChangeOpponentsStatsInEffect(StatType.Def, -5);
    }
}