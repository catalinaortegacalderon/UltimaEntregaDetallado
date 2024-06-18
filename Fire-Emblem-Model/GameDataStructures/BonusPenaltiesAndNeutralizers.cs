namespace ConsoleApp1.GameDataStructures;

public class BonusPenaltiesAndNeutralizers
{
    public int Atk;
    public int AtkFirstAttack;
    public int AtkFollowup;
    public int Def;
    public int DefFirstAttack;
    public bool HpBonusActivated = false;
    public int Res;
    public int ResFirstAttack;
    public int Spd;

    public BonusPenaltiesAndNeutralizers(int startValuesIn)
    {
        Atk = startValuesIn;
        Spd = startValuesIn;
        Def = startValuesIn;
        Res = startValuesIn;
        AtkFollowup = startValuesIn;
        AtkFirstAttack = startValuesIn;
        DefFirstAttack = startValuesIn;
        ResFirstAttack = startValuesIn;
    }
}