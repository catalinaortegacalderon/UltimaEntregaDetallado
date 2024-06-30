using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects
{
    public class GuardBearingEffect : Effect
    {
        public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
        {
            var percentage = CalculatePercentage(myUnit, opponentsUnit);
            ApplyPercentage(myUnit, percentage);
        }

        private static double CalculatePercentage(Unit myUnit, Unit opponentsUnit)
        {
            const double defaultPercentage = 0.7;
            const double specialCasePercentage = 0.4;
            
            var percentage = defaultPercentage;
            
            if (IsTheFirstTimeMyUnitsStartsTheCombat(myUnit) ||
                IsTheFirstTimeMyUnitIsInACombatStartedByTheOpponent(myUnit, opponentsUnit))
            {
                percentage = specialCasePercentage;
            }
            
            if (myUnit.DamageEffects.HasReductionOfPercentageReduction != 1)
            {
                percentage = CalculateNewPercentage(percentage);
            }

            return percentage;
        }

        private static bool IsTheFirstTimeMyUnitsStartsTheCombat(Unit myUnit)
        {
            return !myUnit.HasStartedACombat && myUnit.IsAttacking;
        }
        
        private static bool IsTheFirstTimeMyUnitIsInACombatStartedByTheOpponent(Unit myUnit, Unit opponentsUnit)
        {
            return !myUnit.HasBeenBeenInACombatStartedByTheOpponent && opponentsUnit.IsAttacking;
        }
        
        private static double CalculateNewPercentage(double percentage)
        {
            const double reductionOfPercentageReduction = 0.5;
            percentage = 1 - (1 - percentage) * reductionOfPercentageReduction;
            return percentage;
        }
        
        private static void ApplyPercentage(Unit myUnit, double percentage)
        {
            myUnit.DamageEffects.PercentageReduction *= percentage;
        }
    }
}