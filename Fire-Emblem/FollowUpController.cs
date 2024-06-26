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
             CanDoAFollowup(unitThatDidNotStartTheRound, unitThatStartedTheRound))
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
        // paso por guaranteed followup y imprimo todo
        Console.WriteLine("Paso por can do a followup y imprimo todo");
        Console.WriteLine(attackingUnit.Name + " tiene:");
        
        var combatEffects = attackingUnit.CombatEffects;
        
        Console.WriteLine("HpRecuperationAtEveryAttack: " + combatEffects.HpRecuperationAtEveryAttack);
        Console.WriteLine("HpRecuperationAtTheEndOfTheCombat: " + combatEffects.HpRecuperationAtTheEndOfTheCombat);
        Console.WriteLine("DamageBeforeCombat: " + combatEffects.DamageBeforeCombat);
        Console.WriteLine("DamageAfterCombat: " + combatEffects.DamageAfterCombat);
        Console.WriteLine("DamageAfterCombatIfUnitAttacks: " + combatEffects.DamageAfterCombatIfUnitAttacks);
        Console.WriteLine("HasCounterAttackDenial: " + combatEffects.HasCounterAttackDenial);
        Console.WriteLine("HasNeutralizationOfCounterattackDenial: " + combatEffects.HasNeutralizationOfCounterattackDenial);
        Console.WriteLine("HasGuaranteedFollowUp: " + combatEffects.HasGuaranteedFollowUp);
        Console.WriteLine("AmountOfEffectsThatGuaranteeFollowup: " + combatEffects.AmountOfEffectsThatGuaranteeFollowup);
        Console.WriteLine("HasDenialOfGuaranteedFollowUp: " + combatEffects.HasDenialOfGuaranteedFollowUp);
        Console.WriteLine("HasFollowUpDenial: " + combatEffects.HasFollowUpDenial);
        Console.WriteLine("AmountOfEffectsThatDenyFollowup: " + combatEffects.AmountOfEffectsThatDenyFollowup);
        Console.WriteLine("HasNeutralizationOfFollowUpDenial: " + combatEffects.HasNeutralizationOfFollowUpDenial);
        
        
        if (!ThereAreNoLosers())
            return false;
        // parace que followup denial le gana a guaranteed followup, mix parte 2 test 10, pero me causa ruido con test 11
        // tal vez si parte la ronda entonces guaranteed followup le gana a followup denial?
        
        // paso mas tests con followup denial primero
        
        // me falto comparar los numeros
        
        // manejar caso que tiene followup denial y guarantee followup, todo: poner esto mucho mas bonito

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