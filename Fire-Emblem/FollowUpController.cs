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
        
        // todo: flujo normal
        
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
            _attackController.SetCurrentAttacker(_idOfThePlayerThatDidntStartTheRound);
            _attackController.GenerateAnAttackBetweenTwoUnits(AttackType.FollowUp, 
                _unitThatDidNotStartTheRound, 
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
        
        // si uno ya lo hizo pero le toca al otro
        
        // todo: FIRST CHECK IF ROUND STARTED DID THE FOLLOWUP, EL OTRO HARA EL FOLLOWUP
        // los dos metodos de abajo se parecen mucho
        if (CanDoAFollowup(unitThatStartedTheRound, unitThatDidNotStartTheRound) &&
            (_unitThatDidNotStartTheRound.CombatEffects.HasGuaranteedFollowUp || 
             CanDoAFollowup(unitThatDidNotStartTheRound, unitThatStartedTheRound)))
        {
            Console.WriteLine("PASO POR AQUI");
            _attackController.SetCurrentAttacker(_idOfThePlayerThatDidntStartTheRound);
            _attackController.GenerateAnAttackBetweenTwoUnits(AttackType.FollowUp, 
                _unitThatDidNotStartTheRound, 
                _unitThatStartedTheRound);
        }
        
        if (CanDoAFollowup(unitThatStartedTheRound, unitThatDidNotStartTheRound) &&
            CanDoAFollowup(unitThatDidNotStartTheRound, unitThatStartedTheRound)
            )
        {
            Console.WriteLine("PASO POR AQUI 2");
            _attackController.SetCurrentAttacker(_idOfThePlayerThatDidntStartTheRound);
            //_attackController.GenerateAnAttackBetweenTwoUnits(AttackType.FollowUp, 
            //    _unitThatDidNotStartTheRound, 
            //    _unitThatStartedTheRound);
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
        if (!ThereAreNoLosers())
            return false;
        if (attackingUnit.CombatEffects.HasFollowUpDenial
            && ! attackingUnit.CombatEffects.HasNeutralizationOfFollowUpDenial)
            return false;
        if (attackingUnit.CombatEffects.HasGuaranteedFollowUp
            && !attackingUnit.CombatEffects.HasDenialOfGuaranteedFollowUp)
            return true;
        
        // todo: revisar, followup denial, condicion, guaranteed...
        const int additionValueForFollowupCondition = 5;
        // todo: encapsular esto en otra parte
        bool doesFollowupConditionHold = TotalStatGetter.GetTotal(StatType.Spd, defensiveUnit) +
            + additionValueForFollowupCondition
            <= TotalStatGetter.GetTotal(StatType.Spd, attackingUnit);

        return doesFollowupConditionHold;
    }

    private bool ThereAreNoLosers()
    {
        return _unitThatStartedTheRound.Hp != 0 
               && _unitThatDidNotStartTheRound.Hp != 0;
    }
}