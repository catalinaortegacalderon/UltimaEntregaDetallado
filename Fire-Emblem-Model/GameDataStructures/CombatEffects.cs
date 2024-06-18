namespace ConsoleApp1.GameDataStructures;

public class CombatEffects
// todo: revisar este nombre
{
    public double HpRecuperationAtEveryAttack = 0;
    
    public int HpRecuperationAtTheEndOfTheCombat = 0; // imp
    
    public double HpLostAtTheBeginning = 0; // implementar
    
    public int DamageBeforeCombat = 0; 
    public int DamageAfterCombat = 0; 
    public int DamageAfterCombatIfUnitAttacks = 0; // habra un contador para la unidad,  luego se suma a lo otro si se cumple
    
    public bool HasCounterAttackDenial = false;
    public bool HasNeutralizationOfCounterattackDenial = false;
    
    public bool HasGuaranteedFollowUp = false;
    public int AmountOfEffectsThatGuaranteeFollowup = 0;
    
    public bool HasDenialOfGuaranteedFollowUp = false;
    
    public bool HasFollowUpDenial = false;
    public int AmountOfEffectsThatDenyFollowup = 0;
    public bool HasNeutralizationOfFollowUpDenial = false;
}