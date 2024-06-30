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
        PrintBonus(view, unit);
        PrintPenalties(view, unit);
        PrintBonusNetralization(view, unit);
        PrintPenaltyNetralization(view, unit);
        PrintDamageEffects(view, unit);
        PrintCombatEffects(view, unit);
    }

    private static void PrintBonus(View view, Unit unit)
    {
        PrintOneBonus(unit.ActiveBonus.Atk, "Atk", "");
        PrintOneBonus(unit.ActiveBonus.Spd, "Spd", "");
        PrintOneBonus(unit.ActiveBonus.Def, "Def", "");
        PrintOneBonus(unit.ActiveBonus.Res, "Res", "");
        PrintOneBonus(unit.ActiveBonus.AtkFirstAttack, "Atk", " en su primer ataque");
        PrintOneBonus(unit.ActiveBonus.DefFirstAttack, "Def", " en su primer ataque");
        PrintOneBonus(unit.ActiveBonus.ResFirstAttack, "Res", " en su primer ataque");
        PrintOneBonus(unit.ActiveBonus.AtkFollowup, "Atk", " en su Follow-Up");
    }

    private static void PrintOneBonus(int bonus, string skill, string extraInformation)
    {
        if (bonus > 0)
            _view.WriteLine(_unit.Name + " obtiene " + skill + "+" + bonus + extraInformation);
    }

    private static void PrintPenalties(View view, Unit unit)
    {
        PrintOnePenalty(unit.ActivePenalties.Atk, "Atk", "");
        PrintOnePenalty(unit.ActivePenalties.Spd, "Spd", "");
        PrintOnePenalty(unit.ActivePenalties.Def, "Def", "");
        PrintOnePenalty(unit.ActivePenalties.Res, "Res", "");
        PrintOnePenalty(unit.ActivePenalties.AtkFirstAttack, "Atk", " en su primer ataque");
        PrintOnePenalty(unit.ActivePenalties.DefFirstAttack, "Def", " en su primer ataque");
        PrintOnePenalty(unit.ActivePenalties.ResFirstAttack, "Res", " en su primer ataque");
        PrintOnePenalty(unit.ActivePenalties.AtkFollowup, "Atk", " en su Follow-Up");
    }
    
    private static void PrintOnePenalty(int penalty, string skill, string extraInformation)
    {
        if (penalty < 0)
            _view.WriteLine(_unit.Name + " obtiene " + skill + penalty + extraInformation);
    }

    private static void PrintBonusNetralization(View view, Unit unit)
    {
        PrintOneBonusNeutralization(unit.ActiveBonusNeutralizer.Atk, "Atk");
        PrintOneBonusNeutralization(unit.ActiveBonusNeutralizer.Spd, "Spd");
        PrintOneBonusNeutralization(unit.ActiveBonusNeutralizer.Def, "Def");
        PrintOneBonusNeutralization(unit.ActiveBonusNeutralizer.Res, "Res");
    }

    private static void PrintOneBonusNeutralization(int neutralizer, string stat)
    {
        if (neutralizer == 0)
            _view.WriteLine("Los bonus de " + stat + " de " + _unit.Name + " fueron neutralizados");
    }

    private static void PrintPenaltyNetralization(View view, Unit unit)
    {
        PrintOnePenaltyNeutralization(unit.ActivePenaltiesNeutralizer.Atk, "Atk");
        PrintOnePenaltyNeutralization(unit.ActivePenaltiesNeutralizer.Spd, "Spd");
        PrintOnePenaltyNeutralization(unit.ActivePenaltiesNeutralizer.Def, "Def");
        PrintOnePenaltyNeutralization(unit.ActivePenaltiesNeutralizer.Res, "Res");
    }
    
    private static void PrintOnePenaltyNeutralization(int neutralizer, string stat)
    {
        if (neutralizer == 0)
            _view.WriteLine("Los penalty de " + stat + " de " + _unit.Name + " fueron neutralizados");
    }

    private static void PrintDamageEffects(View view, Unit unit)
    {
        PrintOneDamageEffect(unit.DamageEffects.ExtraDamage, " realizará +", 
            " daño extra en cada ataque");
        PrintOneDamageEffect(unit.DamageEffects.ExtraDamageFirstAttack, " realizará +",
            " daño extra en su primer ataque");
        PrintOneDamageEffect(unit.DamageEffects.ExtraDamageFollowup, " realizará +", 
            " daño extra en su Follow-Up");
        PrintOnePercentageDamageEffect(unit.DamageEffects.PercentageReduction, 
            " reducirá el daño de los ataques del rival en un ", "%");
        PrintOnePercentageDamageEffect(unit.DamageEffects.PercentageReductionOpponentsFirstAttack, 
            " reducirá el daño del primer ataque del rival en un ", "%");
        PrintOnePercentageDamageEffect(unit.DamageEffects.PercentageReductionOpponentsFollowup, 
            " reducirá el daño del Follow-Up del rival en un ", "%");
        PrintOneDamageEffect(unit.DamageEffects.AbsolutDamageReduction, " recibirá ", 
            " daño en cada ataque");
    }
    
    private static void PrintOneDamageEffect(int damage, string firstString, string extraInformation)
    {
        if (damage != 0)
            _view.WriteLine(_unit.Name + firstString + + damage + extraInformation);
    }
    
    private static void PrintOnePercentageDamageEffect(double damage, string firstString, string extraInformation)
    {
        var amount = Math.Round((1 - damage) * 100);
        if (damage != 1)
            _view.WriteLine(_unit.Name + firstString + amount + extraInformation);
    }
    
    private static void PrintCombatEffects(View view, Unit unit)
    {
        if (unit.CombatEffects.HpRecuperationAtEveryAttack > 0)
            view.WriteLine(unit.Name + " recuperará HP igual al " 
                                     + (unit.CombatEffects.HpRecuperationAtEveryAttack * 100) 
                           + "% del daño realizado en cada ataque");
        if (unit.CombatEffects.HasCounterAttackDenial && !unit.CombatEffects.HasNeutralizationOfCounterattackDenial)
            view.WriteLine(unit.Name + " no podrá contraatacar");
        if (unit.CombatEffects.HasNeutralizationOfCounterattackDenial && unit.CombatEffects.HasCounterAttackDenial)
            view.WriteLine(unit.Name + " neutraliza los efectos que previenen sus contraataques");
        if (unit.CombatEffects.HasGuaranteedFollowUp)
            view.WriteLine(unit.Name + " tiene " + unit.CombatEffects.AmountOfEffectsThatGuaranteeFollowup 
                           + " efecto(s) que garantiza(n) su follow up activo(s)");
        if (unit.CombatEffects.HasFollowUpDenial)
            view.WriteLine(unit.Name + " tiene " + unit.CombatEffects.AmountOfEffectsThatDenyFollowup 
                           + " efecto(s) que neutraliza(n) su follow up activo(s)");
        if (unit.CombatEffects.HasNeutralizationOfFollowUpDenial)
            view.WriteLine(unit.Name + " es inmune a los efectos que neutralizan su follow up");
        if (unit.CombatEffects.HasDenialOfGuaranteedFollowUp)
            view.WriteLine(unit.Name + " es inmune a los efectos que garantizan su follow up");
    }
    
    
}