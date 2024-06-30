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

public class FlareSkill : Skill
{
    public FlareSkill()
    {
        Conditions = new Condition[2];
        Conditions[0] = Conditions[1] = new MyUnitUsesCertainWeaponsCondition([WeaponType.Magic]);

        Effects = new Effect[2];
        Effects[0] = new ChangeOpponentsResInPercentageEffect(0.2);
        Effects[1] = new HealingEffect(0.5);
    }
}
