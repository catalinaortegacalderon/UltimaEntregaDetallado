using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class PushSkill : Skill
{
    public PushSkill(StatType firstStat, StatType secondStat)
    {
        Conditions = new Condition[3];
        Conditions[0] = new MyHpIsBiggerThanCondition(0.25);
        Conditions[1] = new MyHpIsBiggerThanCondition(0.25);
        Conditions[2] = new MyHpIsBiggerThanCondition(0.25);
        
        Effects = new Effect[3];
        Effects[0] = new ChangeStatsInEffect(firstStat, 7);
        Effects[1] = new ChangeStatsInEffect(secondStat, 7);
        Effects[2] = new DamageAtTheEndOfTheCombatIfUnitAttacksEffect(5);
    }
}