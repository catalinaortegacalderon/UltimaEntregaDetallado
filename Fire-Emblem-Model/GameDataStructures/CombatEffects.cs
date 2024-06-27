namespace ConsoleApp1.GameDataStructures;

public class CombatEffects
{
    public double HpRecuperationAtEveryAttack = 0;
    
    public int HpRecuperationAtTheEndOfTheCombat = 0; 
    
    public int DamageBeforeCombat = 0; 
    public int DamageAfterCombat = 0; 
    public int DamageAfterCombatIfUnitAttacks = 0; 
    
    public bool HasCounterAttackDenial = false;
    public bool HasNeutralizationOfCounterattackDenial = false;
    
    public bool HasGuaranteedFollowUp = false;
    public int AmountOfEffectsThatGuaranteeFollowup = 0;
    
    public bool HasDenialOfGuaranteedFollowUp = false;
    
    public bool HasFollowUpDenial = false;
    public int AmountOfEffectsThatDenyFollowup = 0;
    public bool HasNeutralizationOfFollowUpDenial = false;
}