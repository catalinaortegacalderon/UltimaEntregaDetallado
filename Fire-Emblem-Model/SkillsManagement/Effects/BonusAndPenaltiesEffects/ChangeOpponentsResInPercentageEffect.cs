using ConsoleApp1.GameDataStructures;
using ConsoleApp1.SkillsManagement.Effects.BaseEffects;

namespace ConsoleApp1.SkillsManagement.Effects.BonusAndPenaltiesEffects;

public class ChangeOpponentsResInPercentageEffect : Effect
{
    private readonly double _percentage;

    public ChangeOpponentsResInPercentageEffect(double percentage)
    {
        _percentage = percentage;
    }

    public override void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
        Amount = 0;
        Amount = Convert.ToInt32(Math.Truncate(opponentsUnit.Res * _percentage));
        opponentsUnit.ActivePenalties.Res -= Amount;
    }
}