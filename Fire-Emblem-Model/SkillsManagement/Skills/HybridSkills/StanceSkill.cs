using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

// ARREGLAR NOMBRES DE PARAMS QUE RECIBE LA FUNCION

// TAMBIEN USO PARA POSTURE, TAL VEZ CAMBIAR ESTO

public class StanceSkill : Skill
{
    public StanceSkill(StatType statThatChanges1, StatType statThatChanges2, int amount1, int amount2)
    {
        Conditions = new Condition[3];
        Conditions[0] = new OpponentStartsCombatCondition();
        Conditions[1] = new OpponentStartsCombatCondition();
        Conditions[2] = new OpponentStartsCombatCondition();
        Effects = new Effect[3];
        Effects[0] = new ChangeStatsInEffect(statThatChanges1, amount1);
        Effects[1] = new ChangeStatsInEffect(statThatChanges2, amount2);
        Effects[2] = new PercentualDamageReductionEffect(0.9, DamageEffectCategory.FollowUp);
    }
}