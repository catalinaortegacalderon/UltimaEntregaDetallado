using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.NeutralizationEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class LightAndDarkSkill : Skill
{
    public LightAndDarkSkill()
    {
        Conditions = new Condition[6];
        Conditions[0] = Conditions[1] = Conditions[2] = Conditions[3] = Conditions[4] = Conditions[5] = 
            new AlwaysTrueCondition();

        Effects = new Effect[6];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Atk, -5);
        Effects[1] = new ChangeOpponentsStatsInEffect(StatType.Spd, -5);
        Effects[2] = new ChangeOpponentsStatsInEffect(StatType.Def, -5);
        Effects[3] = new ChangeOpponentsStatsInEffect(StatType.Res, -5);
        Effects[4] = new NeutralizePenaltiesEffect();
        Effects[5] = new NeutralizeOpponentsBonusEffect();
    }
}