using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.DamageEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class BewitchingTomeSkill : Skill
{
    public BewitchingTomeSkill()
    {
        Conditions = new Condition[9];
        Conditions[0] = new OrCondition([ new MyUnitStartsCombatCondition(), 
            new OpponentUsesCertainWeaponCondition([ Weapon.Magic, Weapon.Bow])]);
        Conditions[0].ChangePriorityBecauseEffectPriorityIsBigger(
            ConditionPriority.PriorityOfConditionsThatRequireBonusAndPenaltiesInformation);
        Conditions[1] = new OrCondition([ new MyUnitStartsCombatCondition(), 
            new OpponentUsesCertainWeaponCondition([ Weapon.Magic, Weapon.Bow])]);
        Conditions[2] = new OrCondition([ new MyUnitStartsCombatCondition(), 
            new OpponentUsesCertainWeaponCondition([ Weapon.Magic, Weapon.Bow])]);
        Conditions[3] = new OrCondition([ new MyUnitStartsCombatCondition(), 
            new OpponentUsesCertainWeaponCondition([ Weapon.Magic, Weapon.Bow])]);
        Conditions[4] = new OrCondition([ new MyUnitStartsCombatCondition(), 
            new OpponentUsesCertainWeaponCondition([ Weapon.Magic, Weapon.Bow])]);
        Conditions[5] = new OrCondition([ new MyUnitStartsCombatCondition(), 
            new OpponentUsesCertainWeaponCondition([ Weapon.Magic, Weapon.Bow])]);
        Conditions[6] = new OrCondition([ new MyUnitStartsCombatCondition(), 
            new OpponentUsesCertainWeaponCondition([ Weapon.Magic, Weapon.Bow])]);
        Conditions[7] = new OrCondition([ new MyUnitStartsCombatCondition(), 
            new OpponentUsesCertainWeaponCondition([ Weapon.Magic, Weapon.Bow])]);
        Conditions[8] = new OrCondition([ new MyUnitStartsCombatCondition(), 
            new OpponentUsesCertainWeaponCondition([ Weapon.Magic, Weapon.Bow])]);

        Effects = new Effect[9];
        Effects[0] = new BewitchingTomeEffect();
        Effects[1] = new ChangeStatsInEffect(StatType.Atk, 5);
        Effects[2] = new ChangeStatsInEffect(StatType.Spd, 5);
        Effects[3] = new ChangeStatsInEffect(StatType.Def, 5);
        Effects[4] = new ChangeStatsInEffect(StatType.Res, 5);
        Effects[5] = new ChangeStatsInBasePercentageEffect(StatType.Spd, 0.2);
        Effects[6] = new ChangeStatInAnotherStatsBasePercentajeEffect(
            StatType.Atk, 0.2, StatType.Spd);
        Effects[7] = new PercentualDamageReductionEffect(0.7, 
            DamageEffectCategory.FirstAttack);
        Effects[8] = new HealingAtTheEndOfTheCombatEffect(7);
    }
}