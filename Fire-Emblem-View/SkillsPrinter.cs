using ConsoleApp1.GameDataStructures;

namespace Fire_Emblem_View;

public class SkillsPrinter
{
    private static Unit _unit;
    private static View _view;

    public static void PrintAll(View view, Unit unit)
    {
        _unit = unit;
        _view = view;
        PrintBonus();
        PrintPenalties();
        PrintBonusNeutralization();
        PrintPenaltyNeutralization();
        PrintDamageEffects();
        PrintCombatEffects();
    }

    private static void PrintBonus()
    {
        PrintOneBonus(_unit.ActiveBonus.Atk, "Atk", "");
        PrintOneBonus(_unit.ActiveBonus.Spd, "Spd", "");
        PrintOneBonus(_unit.ActiveBonus.Def, "Def", "");
        PrintOneBonus(_unit.ActiveBonus.Res, "Res", "");
        PrintOneBonus(_unit.ActiveBonus.AtkFirstAttack, "Atk", " en su primer ataque");
        PrintOneBonus(_unit.ActiveBonus.DefFirstAttack, "Def", " en su primer ataque");
        PrintOneBonus(_unit.ActiveBonus.ResFirstAttack, "Res", " en su primer ataque");
        PrintOneBonus(_unit.ActiveBonus.AtkFollowup, "Atk", " en su Follow-Up");
    }

    private static void PrintOneBonus(int bonus, string skill, string extraInformation)
    {
        if (bonus > 0)
            _view.WriteLine($"{_unit.Name} obtiene {skill}+{bonus}{extraInformation}");
    }

    private static void PrintPenalties()
    {
        PrintOnePenalty(_unit.ActivePenalties.Atk, "Atk", "");
        PrintOnePenalty(_unit.ActivePenalties.Spd, "Spd", "");
        PrintOnePenalty(_unit.ActivePenalties.Def, "Def", "");
        PrintOnePenalty(_unit.ActivePenalties.Res, "Res", "");
        PrintOnePenalty(_unit.ActivePenalties.AtkFirstAttack, "Atk", " en su primer ataque");
        PrintOnePenalty(_unit.ActivePenalties.DefFirstAttack, "Def", " en su primer ataque");
        PrintOnePenalty(_unit.ActivePenalties.ResFirstAttack, "Res", " en su primer ataque");
        PrintOnePenalty(_unit.ActivePenalties.AtkFollowup, "Atk", " en su Follow-Up");
    }

    private static void PrintOnePenalty(int penalty, string skill, string extraInformation)
    {
        if (penalty < 0)
            _view.WriteLine($"{_unit.Name} obtiene {skill}{penalty}{extraInformation}");
    }

    private static void PrintBonusNeutralization()
    {
        PrintOneBonusNeutralization(_unit.ActiveBonusNeutralizer.Atk, "Atk");
        PrintOneBonusNeutralization(_unit.ActiveBonusNeutralizer.Spd, "Spd");
        PrintOneBonusNeutralization(_unit.ActiveBonusNeutralizer.Def, "Def");
        PrintOneBonusNeutralization(_unit.ActiveBonusNeutralizer.Res, "Res");
    }

    private static void PrintOneBonusNeutralization(int neutralizer, string stat)
    {
        if (neutralizer == 0)
            _view.WriteLine($"Los bonus de {stat} de {_unit.Name} fueron neutralizados");
    }

    private static void PrintPenaltyNeutralization()
    {
        PrintOnePenaltyNeutralization(_unit.ActivePenaltiesNeutralizer.Atk, "Atk");
        PrintOnePenaltyNeutralization(_unit.ActivePenaltiesNeutralizer.Spd, "Spd");
        PrintOnePenaltyNeutralization(_unit.ActivePenaltiesNeutralizer.Def, "Def");
        PrintOnePenaltyNeutralization(_unit.ActivePenaltiesNeutralizer.Res, "Res");
    }

    private static void PrintOnePenaltyNeutralization(int neutralizer, string stat)
    {
        if (neutralizer == 0)
            _view.WriteLine($"Los penalty de {stat} de {_unit.Name} fueron neutralizados");
    }

    private static void PrintDamageEffects()
    {
        PrintOneDamageEffect(_unit.DamageEffects.ExtraDamage, " realizará +", " daño extra en cada ataque");
        PrintOneDamageEffect(_unit.DamageEffects.ExtraDamageFirstAttack, " realizará +", " daño extra en su primer ataque");
        PrintOneDamageEffect(_unit.DamageEffects.ExtraDamageFollowup, " realizará +", " daño extra en su Follow-Up");
        PrintOnePercentageDamageEffect(_unit.DamageEffects.PercentageReduction, " reducirá el daño de los ataques del rival en un ", "%");
        PrintOnePercentageDamageEffect(_unit.DamageEffects.PercentageReductionOpponentsFirstAttack, " reducirá el daño del primer ataque del rival en un ", "%");
        PrintOnePercentageDamageEffect(_unit.DamageEffects.PercentageReductionOpponentsFollowup, " reducirá el daño del Follow-Up del rival en un ", "%");
        PrintOneDamageEffect(_unit.DamageEffects.AbsoluteDamageReduction, " recibirá ", " daño en cada ataque");
    }

    private static void PrintOneDamageEffect(int damage, string firstString, string extraInformation)
    {
        if (damage != 0)
            _view.WriteLine($"{_unit.Name}{firstString}{damage}{extraInformation}");
    }

    private static void PrintOnePercentageDamageEffect(double damage, string firstString, string extraInformation)
    {
        var amount = Math.Round((1 - damage) * 100);
        if (damage != 1)
            _view.WriteLine($"{_unit.Name}{firstString}{amount}{extraInformation}");
    }

    private static void PrintCombatEffects()
    {
        if (_unit.CombatEffects.HpRecuperationAtEveryAttack > 0)
            _view.WriteLine($"{_unit.Name} recuperará HP igual al {(_unit.CombatEffects.HpRecuperationAtEveryAttack * 100)}% del daño realizado en cada ataque");
        if (_unit.CombatEffects.HasCounterAttackDenial && !_unit.CombatEffects.HasNeutralizationOfCounterattackDenial)
            _view.WriteLine($"{_unit.Name} no podrá contraatacar");
        if (_unit.CombatEffects.HasNeutralizationOfCounterattackDenial && _unit.CombatEffects.HasCounterAttackDenial)
            _view.WriteLine($"{_unit.Name} neutraliza los efectos que previenen sus contraataques");
        if (_unit.CombatEffects.HasGuaranteedFollowUp)
            _view.WriteLine($"{_unit.Name} tiene {_unit.CombatEffects.AmountOfEffectsThatGuaranteeFollowup} efecto(s) que garantiza(n) su follow up activo(s)");
        if (_unit.CombatEffects.HasFollowUpDenial)
            _view.WriteLine($"{_unit.Name} tiene {_unit.CombatEffects.AmountOfEffectsThatDenyFollowup} efecto(s) que neutraliza(n) su follow up activo(s)");
        if (_unit.CombatEffects.HasNeutralizationOfFollowUpDenial)
            _view.WriteLine($"{_unit.Name} es inmune a los efectos que neutralizan su follow up");
        if (_unit.CombatEffects.HasDenialOfGuaranteedFollowUp)
            _view.WriteLine($"{_unit.Name} es inmune a los efectos que garantizan su follow up");
    }
}
