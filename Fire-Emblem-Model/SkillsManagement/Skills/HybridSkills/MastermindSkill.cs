using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class MastermindSkill : Skill
{
    public MastermindSkill()
    {
        Conditions = new Condition[4];
        Conditions[0] = new MyHpIsBiggerThanConstantCondition(2);
        Conditions[1] = new MyUnitStartsCombatCondition();
        Conditions[2] = new MyUnitStartsCombatCondition();
        Conditions[3] = new MyUnitStartsCombatCondition();
        Conditions[3].ChangePriorityBecauseEffectPriorityIsBigger(
            ConditionPriority.PriorityOfConditionsThatRequireBonusAndPenaltiesInformation);

        Effects = new Effect[4];
        Effects[0] = new DamageAtTheBeginningOfTheCombatEffect(1);
        Effects[1] = new ChangeStatsInEffect(StatType.Atk, 9);
        Effects[2] = new ChangeStatsInEffect(StatType.Spd, 9);
        Effects[3] = new MastermindEffect();
    }
}

