using System.Runtime.CompilerServices;
using ConsoleApp1.DataTypes;
using ConsoleApp1.EncapsulatedLists;
using Fire_Emblem_GUI;

namespace ConsoleApp1.GameDataStructures;

public class Unit : IUnit
{
    public readonly GenderType GenderType;
    public readonly WeaponType WeaponType;

    public string Name { get; }
    public string Weapon { get; } = "hOLA";
    public int MaxHp { get; set; } = 0;

    public int Hp { get; set; } = 0;
    public int Atk { get; } = 0;
    public int Spd { get; } = 0;
    public int Def { get; } = 0;
    public int Res { get; } = 0;

    public string[] Skills { get; set; } = [];
    
    public readonly SkillsList SkillsList = new();
    
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
        Name = "";
    }

    public Unit(string name, string weapon, string gender,
        int hp, int maxHp, int atk, int spd, int def, int res)
    {
        Name = name;
        WeaponType = ConvertWeaponStringToWeaponType(weapon);
        if (gender == "Male")
            GenderType = GenderType.Male;
        else
            GenderType = GenderType.Female;
        Weapon = weapon;
        MaxHp = maxHp;
        MaxHp = maxHp;
        Hp = hp;
        Atk = atk;
        Spd = spd;
        Def = def;
        Res = res;
    }

    private static WeaponType ConvertWeaponStringToWeaponType(string weapon)
    {
        return weapon switch
        {
            "Magic" => WeaponType.Magic,
            "Axe" => WeaponType.Axe,
            "Lance" => WeaponType.Lance,
            "Bow" => WeaponType.Bow,
            "Sword" => WeaponType.Sword,
            _ => WeaponType.Empty
        };
    }

    private void ChangeBaseHp(int amount)
    {
        MaxHp += amount;
    }
    
}