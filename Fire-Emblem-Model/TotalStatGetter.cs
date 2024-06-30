using ConsoleApp1.DataTypes;
using ConsoleApp1.Exceptions;
using ConsoleApp1.GameDataStructures;

namespace Fire_Emblem
{
    public static class TotalStatGetter
    {
        public static int GetTotal(StatType stat, Unit unit)
        {
            return stat switch
            {
                StatType.Atk => unit.Atk + unit.ActiveBonus.Atk * unit.ActiveBonusNeutralizer.Atk +
                                unit.ActivePenalties.Atk * unit.ActivePenaltiesNeutralizer.Atk,
                StatType.Def => unit.Def + unit.ActiveBonus.Def * unit.ActiveBonusNeutralizer.Def +
                                unit.ActivePenalties.Def * unit.ActivePenaltiesNeutralizer.Def,
                StatType.Res => unit.Res + unit.ActiveBonus.Res * unit.ActiveBonusNeutralizer.Res +
                                unit.ActivePenalties.Res * unit.ActivePenaltiesNeutralizer.Res,
                StatType.Spd => unit.Spd + unit.ActiveBonus.Spd * unit.ActiveBonusNeutralizer.Spd +
                                unit.ActivePenalties.Spd * unit.ActivePenaltiesNeutralizer.Spd,
                _ => throw new UnsupportedStatTypeException()
            };
        }
        
        public static int GetFirstAttackStat(StatType stat,Unit unit)
        {
            return stat switch
            {
                StatType.Atk => unit.ActiveBonus.AtkFirstAttack * unit.ActiveBonusNeutralizer.AtkFirstAttack +
                                unit.ActivePenalties.AtkFirstAttack * unit.ActivePenaltiesNeutralizer.AtkFirstAttack,
                StatType.Def => unit.ActiveBonus.DefFirstAttack * unit.ActiveBonusNeutralizer.Def +
                                unit.ActivePenalties.DefFirstAttack * unit.ActivePenaltiesNeutralizer.Def,
                StatType.Res => unit.ActiveBonus.ResFirstAttack * unit.ActiveBonusNeutralizer.Res +
                                unit.ActivePenalties.ResFirstAttack * unit.ActivePenaltiesNeutralizer.Res,
                _ => throw new UnsupportedStatTypeException()
            };
        }
        
        public static int GetFollowUpStat(StatType stat,Unit unit)
        {
            if (stat == StatType.Atk)
                return unit.ActiveBonus.AtkFollowup
                       * unit.ActiveBonusNeutralizer.Atk
                       + unit.ActivePenalties.AtkFollowup
                       * unit.ActivePenaltiesNeutralizer.Atk;
                
            throw new UnsupportedStatTypeException();
        }
        
        public static int GetTotalPenalties(Unit unit)
        {
            return unit.ActivePenalties.Atk 
                   * unit.ActivePenaltiesNeutralizer.Atk
                   + unit.ActivePenalties.Spd * unit.ActivePenaltiesNeutralizer.Spd
                   + unit.ActivePenalties.Def * unit.ActivePenaltiesNeutralizer.Def
                   + unit.ActivePenalties.Res * unit.ActivePenaltiesNeutralizer.Res;

        }

        public static int GetTotalBonus(Unit unit)
        {
            return unit.ActiveBonus.Atk * unit.ActiveBonusNeutralizer.Atk
                   + unit.ActiveBonus.Spd * unit.ActiveBonusNeutralizer.Spd
                   + unit.ActiveBonus.Def * unit.ActiveBonusNeutralizer.Def
                   + unit.ActiveBonus.Res * unit.ActiveBonusNeutralizer.Res;
        }
    }
    
}