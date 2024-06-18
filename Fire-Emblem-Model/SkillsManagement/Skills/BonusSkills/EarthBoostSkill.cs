using ConsoleApp1.DataTypes;
using ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;

namespace ConsoleApp1.SkillsManagement.Skills.BonusSkills;

public class EarthBoostSkill : BoostSkill
{
    public EarthBoostSkill()
    {
        Effects[0] = new ChangeStatsInEffect(StatType.Def, 6);
    }
}