using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Conditions.BaseConditions;
using ConsoleApp1.SkillsManagement.Conditions.FirstCategoryConditions;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;
using ConsoleApp1.SkillsManagement.Effects.NeutralizationEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;

namespace ConsoleApp1.SkillsManagement.Skills.HybridSkills;

public class DistantDefSkill : Skill
{
    public DistantDefSkill()
    {
        Conditions = new Condition[3];
        Conditions[0] = 
            Conditions[1] = 
                    Conditions[2] =
                        new AndCondition([
                            new OpponentUsesCertainWeaponCondition([
                                WeaponType.Magic, 
                                WeaponType.Bow
                            ]), 
                            new OpponentStartsCombatCondition()]);
        
        Effects = new Effect[3];
        Effects[0] = new ChangeStatsInEffect(StatType.Def, 8);
        Effects[1] = new ChangeStatsInEffect(StatType.Res, 8);
        Effects[2] = new NeutralizeOpponentsBonusEffect();
    }
}