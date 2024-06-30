using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;
using ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

namespace ConsoleApp1.SkillsManagement.Effects.DamageEffects;

public class ExtraDamageReductionConsideringOpponentsTotalStatPercentageEffect : Effect
{
    
    private readonly double _percentage;
    private readonly StatType _stat;
    private readonly DamageEffectCategory _type;

    public ExtraDamageReductionConsideringOpponentsTotalStatPercentageEffect(DamageEffectCategory type, 
        StatType stat, double percentage)
    {
        _type = type;
        _stat = stat;
        _percentage = percentage;
    }
    
    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
        var amount = CalculateAmount(opponentsUnit);
        ApplyDamage(myUnit, amount);
    }

    private void ApplyDamage(Unit myUnit, int amount)
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

    private int CalculateAmount(Unit opponentsUnit)
    {
        var amount = _stat switch
        {
            StatType.Res => TotalStatGetter.GetTotal(StatType.Res, opponentsUnit),
            StatType.Atk => TotalStatGetter.GetTotal(StatType.Atk, opponentsUnit),
            StatType.Def => TotalStatGetter.GetTotal(StatType.Def, opponentsUnit),
            StatType.Spd => TotalStatGetter.GetTotal(StatType.Spd, opponentsUnit),
            _ => 0
        };
        
        amount = Convert.ToInt32(Math.Truncate(amount * _percentage));
        
        return amount;
    }
}