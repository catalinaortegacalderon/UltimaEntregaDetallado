using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class FollowUpController
{
    
    private const int IdOfPlayer1 = 0;
    private const int IdOfPlayer2 = 1;
    
    private readonly GameAttacksController _attackController;
    private readonly IView _view;

    private int _idOfTheRoundStarter;
    private int _idOfThePlayerThatDidntStartTheRound;

    private Unit _unitThatStartedTheRound;
    private Unit _unitThatDidNotStartTheRound;
    
    public FollowUpController(GameAttacksController attackController, IView view)
    {
        _attackController = attackController;
        _view = view;
    }
    public void ManageFollowup(Unit unitThatStartedTheRound, Unit unitThatDidNotStartTheRound, 
        int idOfTheRoundStarter)
    {
        SetUnits(unitThatStartedTheRound, unitThatDidNotStartTheRound, idOfTheRoundStarter);
        ManageMainDecisionFlow(unitThatStartedTheRound, unitThatDidNotStartTheRound);
        ExecuteSecondFollowUpIfApplicable(unitThatStartedTheRound, unitThatDidNotStartTheRound);
    }

    private void ExecuteSecondFollowUpIfApplicable(Unit unitThatStartedTheRound, Unit unitThatDidNotStartTheRound)
    {
        if (BothUnitsCanDoAFollowUp(unitThatStartedTheRound, unitThatDidNotStartTheRound))
        {
            GenerateAttack(_idOfThePlayerThatDidntStartTheRound, _unitThatDidNotStartTheRound,
                _unitThatStartedTheRound);
        }

    }

    private bool BothUnitsCanDoAFollowUp(Unit unitThatStartedTheRound, Unit unitThatDidNotStartTheRound)
    {
        return CanDoAFollowup(unitThatStartedTheRound, unitThatDidNotStartTheRound) &&
               CanDoAFollowup(unitThatDidNotStartTheRound, unitThatStartedTheRound);
    }

    private void ManageMainDecisionFlow(Unit unitThatStartedTheRound, Unit unitThatDidNotStartTheRound)
    {
        // todo: falta trabajo aqui
        if (CanDoAFollowup(unitThatStartedTheRound, unitThatDidNotStartTheRound))
        {
            GenerateAttack(_idOfTheRoundStarter, _unitThatStartedTheRound, 
                _unitThatDidNotStartTheRound);
        }
        else if (CanDoAFollowup(unitThatDidNotStartTheRound, unitThatStartedTheRound) &&
                 CanASpecificPlayerCounterAttack(unitThatDidNotStartTheRound))
        {
            GenerateAttack(_idOfThePlayerThatDidntStartTheRound, _unitThatDidNotStartTheRound,
                _unitThatStartedTheRound);
        }
        else if ( AttackerCantDoFollowup() && !CanASpecificPlayerCounterAttack(unitThatDidNotStartTheRound)
                                           && ThereAreNoLosers())
        { 
            _view.AnnounceASpecificUnitCantDoAFollowup(unitThatStartedTheRound.Name);
        }
        else if (ThereAreNoLosers())
        {
            _view.AnnounceNoUnitCanDoAFollowup();
        }
    }

    private void GenerateAttack(int idOfTheRoundStarter, Unit attackingUnit, Unit defensiveUnit)
    {
        _attackController.SetCurrentAttacker(idOfTheRoundStarter);
        _attackController.GenerateAnAttackBetweenTwoUnits(AttackType.FollowUp, attackingUnit, 
            defensiveUnit);
    }

    private void SetUnits(Unit unitThatStartedTheRound, Unit unitThatDidNotStartTheRound, int idOfTheRoundStarter)
    {
        if (idOfTheRoundStarter == IdOfPlayer1)
        {
            _idOfTheRoundStarter = IdOfPlayer1;
            _idOfThePlayerThatDidntStartTheRound = IdOfPlayer2;
        }
        else
        {
            _idOfTheRoundStarter = IdOfPlayer2;
            _idOfThePlayerThatDidntStartTheRound = IdOfPlayer1;
        }

        _unitThatStartedTheRound = unitThatStartedTheRound;
        _unitThatDidNotStartTheRound = unitThatDidNotStartTheRound;
    }

    private bool AttackerCantDoFollowup()
    {
        return !CanDoAFollowup(_unitThatStartedTheRound, _unitThatDidNotStartTheRound);
    }

    private bool CanASpecificPlayerCounterAttack(Unit unit)
    {
        return !unit.CombatEffects.HasCounterAttackDenial || 
                   unit.CombatEffects.HasNeutralizationOfCounterattackDenial;;
    }

    private bool CanDoAFollowup(Unit attackingUnit, Unit defensiveUnit)
    {
        // todo: arreglar aca
        if (!ThereAreNoLosers())
            return false;
        if (attackingUnit.CombatEffects.HasFollowUpDenial
            && !attackingUnit.CombatEffects.HasNeutralizationOfFollowUpDenial &&
            attackingUnit.CombatEffects.HasGuaranteedFollowUp
            && !attackingUnit.CombatEffects.HasDenialOfGuaranteedFollowUp &&
            (attackingUnit.CombatEffects.AmountOfEffectsThatGuaranteeFollowup ==
             attackingUnit.CombatEffects.AmountOfEffectsThatDenyFollowup))
            return DoesSpdFollowupConditionHold(attackingUnit, defensiveUnit);
        if (attackingUnit.CombatEffects.HasFollowUpDenial
            && !attackingUnit.CombatEffects.HasNeutralizationOfFollowUpDenial &&
            attackingUnit.CombatEffects.HasGuaranteedFollowUp
            && !attackingUnit.CombatEffects.HasDenialOfGuaranteedFollowUp)
            return attackingUnit.CombatEffects.AmountOfEffectsThatGuaranteeFollowup >
                   attackingUnit.CombatEffects.AmountOfEffectsThatDenyFollowup;
        if (attackingUnit.CombatEffects.HasFollowUpDenial
            && ! attackingUnit.CombatEffects.HasNeutralizationOfFollowUpDenial)
            return false;
        if (attackingUnit.CombatEffects.HasGuaranteedFollowUp
            && !attackingUnit.CombatEffects.HasDenialOfGuaranteedFollowUp)
            return true;

        var doesFollowupConditionHold = DoesSpdFollowupConditionHold(attackingUnit, defensiveUnit);
        return doesFollowupConditionHold;
    }

    private static bool DoesSpdFollowupConditionHold(Unit attackingUnit, Unit defensiveUnit)
    {
        const int additionValueForFollowupCondition = 5;
        
        return  TotalStatGetter.GetTotal(StatType.Spd, defensiveUnit) +
                + additionValueForFollowupCondition
                <= TotalStatGetter.GetTotal(StatType.Spd, attackingUnit);
    }

    private bool ThereAreNoLosers()
    {
        return _unitThatStartedTheRound.Hp != 0 && _unitThatDidNotStartTheRound.Hp != 0;
    }
}