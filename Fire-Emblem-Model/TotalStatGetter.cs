using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;

namespace Fire_Emblem
{
    public static class TotalStatGetter
    {
        // todo: IMPLEMENTAR ESTO
        public static int GetTotal(StatType stat, Unit unit)
        {
            if (stat == StatType.Atk)
            {
                return unit.Atk + unit.ActiveBonus.Atk * unit.ActiveBonusNeutralizer.Atk
                                + unit.ActivePenalties.Atk * unit.ActivePenaltiesNeutralizer.Atk;
            }

            if (stat == StatType.Def)
            {
                return unit.Def + unit.ActiveBonus.Def * unit.ActiveBonusNeutralizer.Def
                                + unit.ActivePenalties.Def * unit.ActivePenaltiesNeutralizer.Def;
            }

            if (stat == StatType.Res)
            {
                return unit.Res + unit.ActiveBonus.Res * unit.ActiveBonusNeutralizer.Res
                                + unit.ActivePenalties.Res * unit.ActivePenaltiesNeutralizer.Res;
            }

            if (stat == StatType.Spd)
            {
                return unit.Spd + unit.ActiveBonus.Spd * unit.ActiveBonusNeutralizer.Spd
                                + unit.ActivePenalties.Spd * unit.ActivePenaltiesNeutralizer.Spd;
            }
            throw new ArgumentException("Unsupported stat type.");
        }
    }
}