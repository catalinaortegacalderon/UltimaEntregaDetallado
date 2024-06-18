using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class BrashAssaultSkill : Skill
{
    public BrashAssaultSkill()
    {
        Conditions = new Condition[5];
        Conditions[0] = new OrCondition([
            new AndCondition([
                new MyHpIsLessThanCondition(0.99),
                new MyUnitStartsCombatCondition()
            ]),

            new AndCondition([
                new MyUnitStartsCombatCondition(),
                new OpponentHasFullHpCondition()
            ])
        ]);
        Conditions[4] = 
            Conditions[3] =
            Conditions[2] =
            Conditions[1] = 
                Conditions[0];
        
        Effects = new Effect[5];
        Effects[0] = new ChangeOpponentsStatsInEffect(StatType.Def, -4);
        Effects[1] = new ChangeOpponentsStatsInEffect(StatType.Res, -4);
        Effects[2] = new PercentualDamageReductionEffect(0.7, DamageEffectCategory.FirstAttack);
        Effects[3] = new GuaranteeFollowUpEffect();
        Effects[4] = new BrashAssaultEffect(0.3);
        
    }
}