using ConsoleApp1;
using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem_View;

namespace Fire_Emblem.Controllers;

public class FollowUpController
{
    private const int Player1Id = 0;
    private const int Player2Id = 1;
    private const int SpeedFollowUpThreshold = 5;

    private readonly GameAttacksController _attackController;
    private readonly IView _view;

    private int _roundStarterId;
    private int _nonStarterId;

    private Unit _roundStarter;
    private Unit _nonStarter;

    public FollowUpController(GameAttacksController attackController, IView view)
    {
        _attackController = attackController;
        _view = view;
    }

    public void ManageFollowup(Unit roundStarter, Unit nonStarter, int roundStarterId)
    {
        SetUnits(roundStarter, nonStarter, roundStarterId);
        HandleMainFlow(roundStarter, nonStarter);
        HandleSecondFollowUpIfApplicable(roundStarter, nonStarter);
    }

    private void HandleSecondFollowUpIfApplicable(Unit roundStarter, Unit nonStarter)
    {
        if (BothUnitsCanFollowUp(roundStarter, nonStarter))
        {
            ExecuteAttack(_nonStarterId, _nonStarter, _roundStarter);
        }
    }

    private bool BothUnitsCanFollowUp(Unit roundStarter, Unit nonStarter)
    {
        return CanFollowUp(roundStarter, nonStarter) && CanFollowUp(nonStarter, 
            roundStarter);
    }

    private void HandleMainFlow(Unit roundStarter, Unit nonStarter)
    {
        if (CanFollowUp(roundStarter, nonStarter))
        {
            ExecuteAttack(_roundStarterId, _roundStarter, _nonStarter);
        }
        else if (CanFollowUp(nonStarter, roundStarter) && CanCounterAttack(nonStarter))
        {
            ExecuteAttack(_nonStarterId, _nonStarter, _roundStarter);
        }
        else if (CannotFollowUp(nonStarter))
        {
            _view.AnnounceUnitCannotFollowUp(_roundStarter.Name);
        }
        else if (BothUnitsAlive())
        {
            _view.AnnounceNoUnitCanFollowUp();
        }
    }

    private bool CannotFollowUp(Unit nonStarter)
    {
        return !CanFollowUp(_roundStarter, _nonStarter) && !CanCounterAttack(nonStarter) 
                                                        && BothUnitsAlive();
    }

    private void ExecuteAttack(int attackerId, Unit attacker, Unit defender)
    {
        _attackController.SetCurrentAttacker(attackerId);
        _attackController.GenerateAnAttackBetweenTwoUnits(AttackType.FollowUp, attacker, defender);
    }

    private void SetUnits(Unit roundStarter, Unit nonStarter, int roundStarterId)
    {
        _roundStarterId = roundStarterId == Player1Id ? Player1Id : Player2Id;
        _nonStarterId = roundStarterId == Player1Id ? Player2Id : Player1Id;

        _roundStarter = roundStarter;
        _nonStarter = nonStarter;
    }

    private bool CanCounterAttack(Unit unit)
    {
        return !unit.CombatEffects.HasCounterAttackDenial || unit.CombatEffects.HasNeutralizationOfCounterattackDenial;
    }

    private bool CanFollowUp(Unit attacker, Unit defender)
    {
        if (!BothUnitsAlive()) return false;
        if (HasEqualFollowUpEffects(attacker)) 
            return MeetsSpeedFollowUpCondition(attacker, defender);
        if (HasMixedFollowUpEffects(attacker)) 
            return attacker.CombatEffects.AmountOfEffectsThatGuaranteeFollowup > 
                   attacker.CombatEffects.AmountOfEffectsThatDenyFollowup;
        if (HasFollowUpDenial(attacker)) 
            return false;
        if (HasGuaranteedFollowUp(attacker)) 
            return true;

        return MeetsSpeedFollowUpCondition(attacker, defender);
    }

    private static bool HasGuaranteedFollowUp(Unit unit)
    {
        return unit.CombatEffects.HasGuaranteedFollowUp && !unit.CombatEffects.HasDenialOfGuaranteedFollowUp;
    }

    private static bool HasFollowUpDenial(Unit unit)
    {
        return unit.CombatEffects.HasFollowUpDenial && !unit.CombatEffects.HasNeutralizationOfFollowUpDenial;
    }

    private static bool HasMixedFollowUpEffects(Unit unit)
    {
        return unit.CombatEffects.HasFollowUpDenial && !unit.CombatEffects.HasNeutralizationOfFollowUpDenial &&
               unit.CombatEffects.HasGuaranteedFollowUp && !unit.CombatEffects.HasDenialOfGuaranteedFollowUp;
    }

    private static bool HasEqualFollowUpEffects(Unit unit)
    {
        return unit.CombatEffects.HasFollowUpDenial && !unit.CombatEffects.HasNeutralizationOfFollowUpDenial &&
               unit.CombatEffects.HasGuaranteedFollowUp && !unit.CombatEffects.HasDenialOfGuaranteedFollowUp &&
               unit.CombatEffects.AmountOfEffectsThatGuaranteeFollowup 
               == unit.CombatEffects.AmountOfEffectsThatDenyFollowup;
    }

    private static bool MeetsSpeedFollowUpCondition(Unit attacker, Unit defender)
    {
        return TotalStatGetter.GetTotal(StatType.Spd, defender) + SpeedFollowUpThreshold 
               <= TotalStatGetter.GetTotal(StatType.Spd, attacker);
    }

    private bool BothUnitsAlive()
    {
        return _roundStarter.Hp != 0 && _nonStarter.Hp != 0;
    }
}
