using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class ImpactSkill: Skill
{
    public ImpactSkill(StatType firstStat, StatType secondStat)
    {
        Console.WriteLine("creando");
        Conditions = new Condition[3];
        Conditions[0] = new MyUnitStartsCombatCondition();
        Conditions[1] = new MyUnitStartsCombatCondition();
        Conditions[2] = new MyUnitStartsCombatCondition();

        Effects = new Effect[3];
        Effects[0] = new ChangeStatsInEffect(firstStat, 6);
        Effects[1] = new ChangeStatsInEffect(secondStat, 10);
        Effects[2] = new OpponentFollowUpDenialEffect();
    }
}