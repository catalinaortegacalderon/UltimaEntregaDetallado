using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.ExtraDamageSkills;

public class LunarBraceSkill : Skill
{
    public LunarBraceSkill()
    {
        Conditions = new Condition[1];
        Conditions[0] = new AndCondition([
            new MyUnitUsesCertainWeaponsCondition([
                WeaponType.Sword, WeaponType.Bow,
                WeaponType.Axe, WeaponType.Lance
            ]),
            new MyUnitStartsCombatCondition()
        ]);
        Conditions[0]
            .ChangePriorityBecauseEffectPriorityIsBigger(ConditionPriority
                .PriorityOfConditionsThatRequireBonusAndPenaltiesInformation);

        Effects = new Effect[1];
        Effects[0] = new LunarBraceEffect();
    }
}