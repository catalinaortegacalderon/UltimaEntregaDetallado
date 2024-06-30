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

public class DragonSkinSkill : Skill
{
    public DragonSkinSkill()
    {
       
        Conditions = new Condition[5];
        Conditions[0] = 
            Conditions[1] = 
                Conditions[2] =
                    Conditions[3] =
                        Conditions[4] = 
                            new OrCondition([
                                new OpponentHasHpGreaterThanCondition(0.75), 
                                new OpponentStartsCombatCondition()]);
        
        Effects = new Effect[5];
        Effects[0] = new ChangeStatsInEffect(StatType.Atk, 6);
        Effects[1] = new ChangeStatsInEffect(StatType.Spd, 6);
        Effects[2] = new ChangeStatsInEffect(StatType.Def, 6);
        Effects[3] = new ChangeStatsInEffect(StatType.Res, 6);
        Effects[4] = new NeutralizeOpponentsBonusEffect();
    }
}