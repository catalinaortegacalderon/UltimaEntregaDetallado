using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.NeutralizationEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class LaguzFriendSkill : Skill
{
    public LaguzFriendSkill()
    {
        Conditions = new Condition[5];
        Conditions[0] = new AlwaysTrueCondition();
        Conditions[1] = new AlwaysTrueCondition();
        Conditions[2] = new AlwaysTrueCondition();
        Conditions[3] = new AlwaysTrueCondition();
        Conditions[4] = new AlwaysTrueCondition();
        Effects = new Effect[5];
        Effects[0] = new PercentualDamageReductionEffect(0.5, DamageEffectCategory.All);
        Effects[1] = new ChangeStatsInBasePercentageEffect(StatType.Def, -0.5);
        Effects[2] = new ChangeStatsInBasePercentageEffect(StatType.Res, -0.5);
        Effects[3] = new NeutralizeOneOfMyBonusEffect(StatType.Def);
        Effects[4] = new NeutralizeOneOfMyBonusEffect(StatType.Res);
    }
}