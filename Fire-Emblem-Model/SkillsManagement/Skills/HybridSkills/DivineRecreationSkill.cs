using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class DivineRecreationSkill : Skill
{
    public DivineRecreationSkill()
    {
        Conditions = new Condition[6];
        Conditions[0] = new OpponentHasHpGreaterThanCondition(0.5);
        Conditions[1] = new OpponentHasHpGreaterThanCondition(0.5);
        Conditions[2] = new OpponentHasHpGreaterThanCondition(0.5);
        Conditions[3] = new OpponentHasHpGreaterThanCondition(0.5);
        Conditions[4] = new OpponentHasHpGreaterThanCondition(0.5);
        Conditions[5] = new OpponentHasHpGreaterThanCondition(0.5);

        Effects = new Effect[6];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Spd, -4);
        Effects[1] = new ChangeOpponentsStatsInEffect(StatType.Def, -4);
        Effects[2] = new ChangeOpponentsStatsInEffect(StatType.Atk, -4);
        Effects[3] = new ChangeOpponentsStatsInEffect(StatType.Res, -4);
        Effects[4] = new PercentualDamageReductionEffect(0.7, DamageEffectCategory.FirstAttack);
        Effects[5] = new DivineRecreationEffect(1);
    }
}