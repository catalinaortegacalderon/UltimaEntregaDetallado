using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class FireBoostSkill : BoostSkill
{
    public FireBoostSkill()
    {
        Effects[0] = new ChangeStatsInEffect(StatType.Atk, 6);
    }
}