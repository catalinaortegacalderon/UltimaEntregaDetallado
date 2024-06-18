using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class WindBoostSkill : BoostSkill
{
    public WindBoostSkill()
    {
        Effects[0] = new ChangeStatsInEffect(StatType.Spd, 6);
    }
}