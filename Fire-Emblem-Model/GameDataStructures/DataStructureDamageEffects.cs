namespace ConsoleApp1.GameDataStructures;

public class DataStructureDamageEffects
{
    public int AbsolutDamageReduction = 0;
    
    public int ExtraDamage = 0;
    public int ExtraDamageFirstAttack = 0;
    public int ExtraDamageFollowup = 0;
    
    public double PercentageReduction = 1;
    public double PercentageReductionOpponentsFirstAttack = 1;
    public double PercentageReductionOpponentsFollowup = 1;
    
    // todo: ver si uso lo de aca abajo
    //public int AmountOfEffectsOfPercentageReduction = 0;
    //public int AmountOfEffectsOfPercentageReductionOpponentsFirstAttack = 0;
    //public int AmountOfEffectsOfPercentageReductionOpponentsFollowup = 0;
    
    public double ReductionOfPercentageReduction = 1;
    public bool HasReductionOfPercentageReduction = false;
}