using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class SunTwinWingSkill : Skill
{
    public SunTwinWingSkill()
    {
        Conditions = new Condition[4];
        Conditions[0] = Conditions[1] = Conditions[2] = Conditions[3] = new MyHpIsBiggerThanCondition(0.25);

        Effects = new Effect[4];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Spd, -5);
        Effects[1] = new ChangeOpponentsStatsInEffect(StatType.Def, -5);
        Effects[2] = new OpponentDenialOfGuaranteedFollowUpEffect();
        Effects[3] = new NeutralizationOfFollowUpDenialEffect();

    }
}