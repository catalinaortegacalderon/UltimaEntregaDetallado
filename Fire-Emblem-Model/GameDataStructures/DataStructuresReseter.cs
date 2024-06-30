namespace ConsoleApp1.GameDataStructures;

public static class DataStructuresReseter
{
    public static void ResetBonusPenaltiesAndNeutralizersToASpecificValue(BonusPenaltiesAndNeutralizers
        dataStructure, int valueToResetTo)
    {
        dataStructure.Atk = valueToResetTo;
        dataStructure.Spd = valueToResetTo;
        dataStructure.Def = valueToResetTo;
        dataStructure.Res = valueToResetTo;
        
        dataStructure.AtkFirstAttack = valueToResetTo;
        dataStructure.DefFirstAttack = valueToResetTo;
        dataStructure.ResFirstAttack = valueToResetTo;
        
        dataStructure.AtkFollowup = valueToResetTo;
    }

    public static void ResetDamageGameStructure(DataStructureDamageEffects dataStructure)
    {
        dataStructure.ExtraDamage = 0;
        dataStructure.ExtraDamageFirstAttack = 0;
        dataStructure.ExtraDamageFollowup = 0;
        
        dataStructure.PercentageReduction = 1;
        dataStructure.PercentageReductionOpponentsFirstAttack = 1;
        dataStructure.PercentageReductionOpponentsFollowup = 1;
        
        dataStructure.AbsoluteDamageReduction = 0;

        dataStructure.ReductionOfPercentageReduction = 1;
    }
    
    public static void ResetCombatEffects(CombatEffects dataStructure)
    {
        dataStructure.HpRecuperationAtTheEndOfTheCombat = 0;
        dataStructure.HpRecuperationAtEveryAttack = 0;
        
        dataStructure.DamageBeforeCombat = 0;
        dataStructure.DamageAfterCombat = 0;
        dataStructure.DamageAfterCombatIfUnitAttacks = 0;
        
        dataStructure.HasCounterAttackDenial = false;
        dataStructure.HasNeutralizationOfCounterattackDenial = false;
        
        dataStructure.HasGuaranteedFollowUp = false;
        dataStructure.AmountOfEffectsThatGuaranteeFollowup = 0;
        dataStructure.HasDenialOfGuaranteedFollowUp = false;
        
        dataStructure.HasFollowUpDenial = false;
        dataStructure.AmountOfEffectsThatDenyFollowup = 0;
        dataStructure.HasNeutralizationOfFollowUpDenial = false;
    }
    
}