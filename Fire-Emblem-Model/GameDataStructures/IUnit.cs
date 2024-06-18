namespace ConsoleApp1.GameDataStructures;

public interface IUnit
{
    string Name { get ; }
    string Weapon { get ; }
    int MaxHp { get ; }
    int Atk { get ; }
    int Spd { get ; }
    int Def { get ; }
    int Res { get ; }
    string [] Skills { get ; } 
}