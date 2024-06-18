using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class BewitchingTomeEffect : Effect
{
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        // todo: encapsular
        var rivalsAttack = TotalStatGetter.GetTotal(StatType.Atk, opponentsUnit);
        
        // todo: nose si esto es considerando total o solo bonus, parece que esta bien
        var myTotalSpd = TotalStatGetter.GetTotal(StatType.Spd, myUnit);
        var opponentsTotalSpd  = TotalStatGetter.GetTotal(StatType.Spd, opponentsUnit);

        var myUnitHasWeaponAdvantage = DamageCalculator.DoesAttackerHaveAdvantage(myUnit.Weapon,
            opponentsUnit.Weapon);
        
        int amount;
        
        if (myTotalSpd > opponentsTotalSpd || myUnitHasWeaponAdvantage)
        {
            amount = (int) (rivalsAttack * 0.4); 
        }
        else
        {
            amount = (int) (rivalsAttack * 0.2); 
        }

        opponentsUnit.CombatEffects.DamageBeforeCombat += amount;
    }
}