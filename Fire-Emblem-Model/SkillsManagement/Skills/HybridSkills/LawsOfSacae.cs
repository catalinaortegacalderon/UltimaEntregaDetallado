using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Conditions.SecondCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.CombatEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class LawsOfSacae : Skill
{
    public LawsOfSacae()
    {
        Conditions = new Condition[5];
        Conditions[0] = new MyUnitStartsCombatCondition();
        Conditions[1] = new MyUnitStartsCombatCondition();
        Conditions[2] = new MyUnitStartsCombatCondition();
        Conditions[3] = new MyUnitStartsCombatCondition();
        Conditions[4] = new AndCondition([ new MyUnitStartsCombatCondition(),
            new CompareTotalSpdAddingSpdToTheOpponent(5), 
            new OpponentUsesCertainWeaponCondition([Weapon.Sword, Weapon.Axe, Weapon.Lance])]); 
        
        Effects = new Effect[5];
        Effects[0] = new ChangeStatsInEffect(StatType.Atk, 6);
        Effects[1] = new ChangeStatsInEffect(StatType.Spd, 6);
        Effects[2] = new ChangeStatsInEffect(StatType.Res, 6);
        Effects[3] = new ChangeStatsInEffect(StatType.Def, 6);
        Effects[4] = new CounterAttackDenialOnOpponentEffect();
    }
}