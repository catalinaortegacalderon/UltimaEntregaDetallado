using ConsoleApp1.DataTypes;
using ConsoleApp1.GameDataStructures;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class FollowUpController
{
    
    private const int IdOfPlayer1 = 0;
    private const int IdOfPlayer2 = 1;
    
    private readonly GameAttacksController _attackController;
    private readonly GameView _view;

    private int _idOfTheRoundStarter;
    private int _otherPlayersId;

    private Unit _unitThatStartedTheRound;
    private Unit _unitThatDidNotStartTheRound;
    
    public FollowUpController(GameAttacksController attackController, GameView view)
    {
        _attackController = attackController;
        _view = view;
    }
    public void ManageFollowup(Unit unitThatStartedTheRound, Unit unitThatDidNotStartTheRound, 
        int idOfTheRoundStarter)
    {
        if (idOfTheRoundStarter == IdOfPlayer1)
        {
            _idOfTheRoundStarter = IdOfPlayer1;
            _otherPlayersId = IdOfPlayer2;
        }
        else
        {
            _idOfTheRoundStarter = IdOfPlayer2;
            // todo: cambiar este nombre
            _otherPlayersId = IdOfPlayer1;
        }

        _unitThatStartedTheRound = unitThatStartedTheRound;
        _unitThatDidNotStartTheRound = unitThatDidNotStartTheRound;
        
        if (CanDoAFollowup(unitThatStartedTheRound, unitThatDidNotStartTheRound))
        {
            _attackController.SetCurrentAttacker(_idOfTheRoundStarter);
            _attackController.GenerateAnAttackBetweenTwoUnits(AttackType.FollowUp, 
                _unitThatStartedTheRound, 
                _unitThatDidNotStartTheRound);
        }
        else if (CanDoAFollowup(unitThatDidNotStartTheRound, unitThatStartedTheRound) &&
                 CanASpecificPlayerCounterAttack(unitThatDidNotStartTheRound))
        {
            _attackController.SetCurrentAttacker(_otherPlayersId);
            _attackController.GenerateAnAttackBetweenTwoUnits(AttackType.FollowUp, 
                _unitThatDidNotStartTheRound, 
                _unitThatStartedTheRound);
        }
        else if ( AttackerCantDoFollowup() && !CanASpecificPlayerCounterAttack(unitThatDidNotStartTheRound)
                 && ThereAreNoLoosers())
        { 
            _view.AnnounceASpecificUnitCantDoAFollowup(unitThatStartedTheRound.Name);
        }
        else if (ThereAreNoLoosers())
        {
            _view.AnnounceNoUnitCanDoAFollowup();
        }
        
        // todo: FIRST CHECK IF ROUND STARTED DID THE FOLLOWUP
        // los dos metodos de abajo se parecen mucho
        if (CanDoAFollowup(unitThatStartedTheRound, unitThatDidNotStartTheRound) &&
            _unitThatDidNotStartTheRound.CombatEffects.HasGuaranteedFollowUp)
        {
            Console.WriteLine("PASO POR AQUI");
            _attackController.SetCurrentAttacker(_otherPlayersId);
            _attackController.GenerateAnAttackBetweenTwoUnits(AttackType.FollowUp, 
                _unitThatDidNotStartTheRound, 
                _unitThatStartedTheRound);
        }
        
        if (CanDoAFollowup(unitThatStartedTheRound, unitThatDidNotStartTheRound) &&
            CanDoAFollowup(unitThatDidNotStartTheRound, unitThatStartedTheRound))
        {
            Console.WriteLine("PASO POR AQUI");
            _attackController.SetCurrentAttacker(_otherPlayersId);
            _attackController.GenerateAnAttackBetweenTwoUnits(AttackType.FollowUp, 
                _unitThatDidNotStartTheRound, 
                _unitThatStartedTheRound);
        }
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
        if (!ThereAreNoLoosers())
            return false;
        if (attackingUnit.CombatEffects.HasFollowUpDenial
            && ! attackingUnit.CombatEffects.HasNeutralizationOfFollowUpDenial)
            return false;
        if (attackingUnit.CombatEffects.HasGuaranteedFollowUp
            && !attackingUnit.CombatEffects.HasDenialOfGuaranteedFollowUp)
            return true;
        
        // revisar, followup denial, condicion, guaranteed...
        const int additionValueForFollowupCondition = 5;
        bool doesFollowupConditionHold =
            defensiveUnit.Spd
            + defensiveUnit.ActiveBonus.Spd * defensiveUnit.ActiveBonusNeutralizer.Spd
            + defensiveUnit.ActivePenalties.Spd * defensiveUnit.ActivePenaltiesNeutralizer.Spd
            + additionValueForFollowupCondition
            <= attackingUnit.Spd
            + attackingUnit.ActiveBonus.Spd * attackingUnit.ActiveBonusNeutralizer.Spd
            + attackingUnit.ActivePenalties.Spd * attackingUnit.ActivePenaltiesNeutralizer.Spd;

        return doesFollowupConditionHold;
    }

    private bool ThereAreNoLoosers()
    {
        return _unitThatStartedTheRound.CurrentHp != 0 
               && _unitThatDidNotStartTheRound.CurrentHp != 0;
    }
}