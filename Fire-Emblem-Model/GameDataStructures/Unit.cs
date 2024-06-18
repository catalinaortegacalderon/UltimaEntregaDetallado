using ConsoleApp1.DataTypes;
using ConsoleApp1.EncapsulatedLists;

namespace ConsoleApp1.GameDataStructures;

public class Unit
{
    public readonly Gender Gender;
    public readonly string Name = "";
    public readonly Weapon Weapon;
    
    public readonly int Atk;
    public readonly int Def;
    public readonly int Res;
    public readonly int Spd;
    public int CurrentHp;
    public int HpMax;
    
    public readonly SkillsList Skills = new();
    
    public readonly BonusPenaltiesAndNeutralizers ActiveBonus = new(0);
    public readonly BonusPenaltiesAndNeutralizers ActiveBonusNeutralizer = new(1);
    public readonly BonusPenaltiesAndNeutralizers ActivePenalties = new(0);
    public readonly BonusPenaltiesAndNeutralizers ActivePenaltiesNeutralizer = new(1);
    public readonly DataStructureDamageEffects DamageEffects = new();
    public readonly CombatEffects CombatEffects = new();
    
    public bool HasBeenBeenInACombatStartedByTheOpponent = false;
    public bool HasStartedACombat = false;
    public string LastOpponentName = "";
    public bool StartedTheRound;
    public bool IsAttacking;
    public bool HasAttackedThisRound;
    public bool HasAnAllyWithMagic = false;

    public Unit()
    {
    }

    public Unit(string name, string weapon, string gender,
        int currentHp, int maxHp, int atk, int spd, int def, int res)
    {
        Name = name;
        Weapon = ConvertWeaponStringToWeaponType(weapon);
        if (gender == "Male")
            Gender = Gender.Male;
        else
            Gender = Gender.Female;
        HpMax = maxHp;
        CurrentHp = currentHp;
        Atk = atk;
        Spd = spd;
        Def = def;
        Res = res;
    }

    private static Weapon ConvertWeaponStringToWeaponType(string weapon)
    {
        return weapon switch
        {
            "Magic" => Weapon.Magic,
            "Axe" => Weapon.Axe,
            "Lance" => Weapon.Lance,
            "Bow" => Weapon.Bow,
            "Sword" => Weapon.Sword,
            _ => Weapon.Empty
        };
    }
}