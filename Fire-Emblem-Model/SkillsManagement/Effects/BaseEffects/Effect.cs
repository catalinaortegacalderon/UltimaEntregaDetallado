using ConsoleApp1.GameDataStructures;

namespace ConsoleApp1.SkillsManagement.Effects.SpecificSkillEffects;

public class Effect
{
    protected int Amount;
    protected int Priority;

    public Effect()
    {
        Priority = 1;
    }

    public virtual void ApplyEffect(Unit myUnit, Unit opponentsUnit)

    {
    }

    public virtual int GetPriority()
    {
        return Priority;
    }
}