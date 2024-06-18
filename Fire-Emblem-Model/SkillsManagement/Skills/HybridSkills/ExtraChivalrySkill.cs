using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class ExtraChivalrySkill : Skill
{
    public ExtraChivalrySkill()
    {
        Conditions = new Condition[4];
        Conditions[0] = new OpponentHasHpGreaterThanCondition(0.5);
        Conditions[1] = new OpponentHasHpGreaterThanCondition(0.5);
        Conditions[2] = new OpponentHasHpGreaterThanCondition(0.5);
        Conditions[3] = new AlwaysTrueCondition();
        Effects = new Effect[4];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Atk, -5);
        Effects[1] = new ChangeOpponentsStatsInEffect(StatType.Def, -5);
        Effects[2] = new ChangeOpponentsStatsInEffect(StatType.Spd, -5);
        Effects[3] = new PercentualDamageReductionConsideringOpponentsHpEffect(DamageEffectCategory.All);
    }
}