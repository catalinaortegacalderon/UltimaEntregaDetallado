using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.PenaltySkills;

public class LunaSkill : Skill
{
    public LunaSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = Conditions[1] = new AlwaysTrueCondition();

        Effects = new Effect[2];
        Effects[0] = new ReduceOpponentsDefInPercentajeForFirstAttackEffect(0.5);
        Effects[1] = new ReduceOpponentsResInPercentageForFirstAttackEffect(0.5);
    }
}