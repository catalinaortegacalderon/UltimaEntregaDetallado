using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects
{
    public class SoulBladeEffect : Effect
    {
        public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
        {
            double refDesAverage = (opponentsUnit.Def + opponentsUnit.Res) / 2;
            var refDesAverageInt = Convert.ToInt32(Math.Truncate(refDesAverage));

            ApplyStatChange(opponentsUnit, refDesAverageInt, StatType.Res);
            ApplyStatChange(opponentsUnit, refDesAverageInt, StatType.Def);
        }

        private static void ApplyStatChange(Unit opponentsUnit, int refDesAverageInt, StatType stat)
        {
            var currentStatValue = stat == StatType.Def ? opponentsUnit.Def : opponentsUnit.Res;
            var change = refDesAverageInt - currentStatValue;

            if (change < 0)
            {
                if (stat == StatType.Def)
                    opponentsUnit.ActivePenalties.Def += change;
                else
                    opponentsUnit.ActivePenalties.Res += change;
            }
            else
            {
                if (stat == StatType.Def)
                    opponentsUnit.ActiveBonus.Def += change;
                else
                    opponentsUnit.ActiveBonus.Res += change;
            }
        }
    }
}