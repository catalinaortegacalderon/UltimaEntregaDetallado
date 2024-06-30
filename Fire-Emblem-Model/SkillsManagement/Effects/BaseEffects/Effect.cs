using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Effects.BaseEffects;

public class Effect
{
    protected int Amount;

    public virtual void ApplyEffect(Unit myUnit, Unit opponentsUnit)
    {
    }
}