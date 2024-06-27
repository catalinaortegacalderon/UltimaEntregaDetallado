using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;
using Fire_Emblem;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;


public class ExtraDamageReductionConsideringMyTotalStatPercentageEffect : Effect
{
    
    private readonly double _percentage;
    private readonly StatType _stat;
    private readonly DamageEffectCategory _type;

    public ExtraDamageReductionConsideringMyTotalStatPercentageEffect(DamageEffectCategory type, 
        StatType stat, double percentage)
    {
        _type = type;
        _stat = stat;
        _percentage = percentage;
    }
    
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        var amount = CalculateAmount(myUnit);
        AddAmountToDamage(myUnit, amount);
    }
    
    private int CalculateAmount(Unit myUnit)
    {
        var amount = _stat switch
        {
            StatType.Res => TotalStatGetter.GetTotal(StatType.Res, myUnit),
            StatType.Atk => TotalStatGetter.GetTotal(StatType.Atk, myUnit),
            StatType.Def => TotalStatGetter.GetTotal(StatType.Def, myUnit),
            StatType.Spd => TotalStatGetter.GetTotal(StatType.Spd, myUnit),
            _ => 0
        };

        amount = Convert.ToInt32(Math.Truncate(amount * _percentage));
        return amount;
    }

    private void AddAmountToDamage(Unit myUnit, int amount)
    {
        switch (_type)
        {
            case DamageEffectCategory.All:
                myUnit.DamageEffects.ExtraDamage += amount;
                break;
            case DamageEffectCategory.FirstAttack:
                myUnit.DamageEffects.ExtraDamageFirstAttack += amount;
                break;
            case DamageEffectCategory.FollowUp:
                myUnit.DamageEffects.ExtraDamageFollowup += amount;
                break;
        }
    }
}