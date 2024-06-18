using ConsoleApp1.GameDataStructures;

namespace Fire_Emblem_View;

public class SkillsPrinter
{
    public static void PrintAll(View view, Unit unit)
    {
        PrintBonus(view, unit);
        PrintPenalties(view, unit);
        PrintBonusNetralization(view, unit);
        PrintPenaltyNetralization(view, unit);
        PrintDamageEffects(view, unit);
        PrintCombatEffects(view, unit);
    }

    private static void PrintBonus(View view, Unit unit)
    {
        if (unit.ActiveBonus.Atk > 0)
            view.WriteLine(unit.Name + " obtiene Atk+" + unit.ActiveBonus.Atk);
        if (unit.ActiveBonus.Spd > 0)
            view.WriteLine(unit.Name + " obtiene Spd+" + unit.ActiveBonus.Spd);
        if (unit.ActiveBonus.Def > 0)
            view.WriteLine(unit.Name + " obtiene Def+" + unit.ActiveBonus.Def);
        if (unit.ActiveBonus.Res > 0)
            view.WriteLine(unit.Name + " obtiene Res+" + unit.ActiveBonus.Res);
        if (unit.ActiveBonus.AtkFirstAttack > 0)
            view.WriteLine(unit.Name + " obtiene Atk+" + unit.ActiveBonus.AtkFirstAttack
                           + " en su primer ataque");
        if (unit.ActiveBonus.DefFirstAttack > 0)
            view.WriteLine(unit.Name + " obtiene Def+" + unit.ActiveBonus.DefFirstAttack
                           + " en su primer ataque");
        if (unit.ActiveBonus.ResFirstAttack > 0)
            view.WriteLine(unit.Name + " obtiene Res+" + unit.ActiveBonus.ResFirstAttack
                           + " en su primer ataque");
        if (unit.ActiveBonus.AtkFollowup > 0)
            view.WriteLine(unit.Name + " obtiene Atk+" + unit.ActiveBonus.AtkFollowup
                           + " en su Follow-Up");
    }

    private static void PrintPenalties(View view, Unit unit)
    {
        if (unit.ActivePenalties.Atk < 0)
            view.WriteLine(unit.Name + " obtiene Atk" + unit.ActivePenalties.Atk);
        if (unit.ActivePenalties.Spd < 0)
            view.WriteLine(unit.Name + " obtiene Spd" + unit.ActivePenalties.Spd);
        if (unit.ActivePenalties.Def < 0)
            view.WriteLine(unit.Name + " obtiene Def" + unit.ActivePenalties.Def);
        if (unit.ActivePenalties.Res < 0)
            view.WriteLine(unit.Name + " obtiene Res" + unit.ActivePenalties.Res);
        if (unit.ActivePenalties.AtkFirstAttack < 0)
            view.WriteLine(unit.Name + " obtiene Atk" + unit.ActivePenalties.AtkFirstAttack
                           + " en su primer ataque");
        if (unit.ActivePenalties.DefFirstAttack < 0)
            view.WriteLine(unit.Name + " obtiene Def" + unit.ActivePenalties.DefFirstAttack
                           + " en su primer ataque");
        if (unit.ActivePenalties.ResFirstAttack < 0)
            view.WriteLine(unit.Name + " obtiene Res" + unit.ActivePenalties.ResFirstAttack
                           + " en su primer ataque");
        if (unit.ActivePenalties.AtkFollowup < 0)
            view.WriteLine(unit.Name + " obtiene Atk" + unit.ActivePenalties.AtkFollowup
                           + " en su Follow-Up");
    }

    private static void PrintBonusNetralization(View view, Unit unit)
    {
        if (unit.ActiveBonusNeutralizer.Atk == 0)
            view.WriteLine("Los bonus de Atk de " + unit.Name + " fueron neutralizados");
        if (unit.ActiveBonusNeutralizer.Spd == 0)
            view.WriteLine("Los bonus de Spd de " + unit.Name + " fueron neutralizados");
        if (unit.ActiveBonusNeutralizer.Def == 0)
            view.WriteLine("Los bonus de Def de " + unit.Name + " fueron neutralizados");
        if (unit.ActiveBonusNeutralizer.Res == 0)
            view.WriteLine("Los bonus de Res de " + unit.Name + " fueron neutralizados");
    }

    private static void PrintPenaltyNetralization(View view, Unit unit)
    {
        if (unit.ActivePenaltiesNeutralizer.Atk == 0)
            view.WriteLine("Los penalty de Atk de " + unit.Name + " fueron neutralizados");
        if (unit.ActivePenaltiesNeutralizer.Spd == 0)
            view.WriteLine("Los penalty de Spd de " + unit.Name + " fueron neutralizados");
        if (unit.ActivePenaltiesNeutralizer.Def == 0)
            view.WriteLine("Los penalty de Def de " + unit.Name + " fueron neutralizados");
        if (unit.ActivePenaltiesNeutralizer.Res == 0)
            view.WriteLine("Los penalty de Res de " + unit.Name + " fueron neutralizados");
    }

    private static void PrintDamageEffects(View view, Unit unit)
    {
        if (unit.DamageEffects.ExtraDamage != 0)
            view.WriteLine(unit.Name + " realizará +" + unit.DamageEffects.ExtraDamage
                           + " daño extra en cada ataque");
        if (unit.DamageEffects.ExtraDamageFirstAttack != 0)
            view.WriteLine(unit.Name + " realizará +" + unit.DamageEffects.ExtraDamageFirstAttack
                           + " daño extra en su primer ataque");
        if (unit.DamageEffects.ExtraDamageFollowup != 0)
            view.WriteLine(unit.Name + " realizará +" + unit.DamageEffects.ExtraDamageFollowup
                           + " daño extra en su Follow-Up");
        if (unit.DamageEffects.PercentageReduction != 1.000)
            view.WriteLine(unit.Name + " reducirá el daño de los ataques del rival en un "
                                     + Math.Round((1 - unit.DamageEffects.PercentageReduction) * 100)
                                     + "%");
        if (unit.DamageEffects.PercentageReductionOpponentsFirstAttack != 1)
            view.WriteLine(unit.Name + " reducirá el daño del primer ataque del rival en un "
                                     + Math.Round(
                                         (1 - unit.DamageEffects.PercentageReductionOpponentsFirstAttack) * 100)
                                     + "%");
        if (unit.DamageEffects.PercentageReductionOpponentsFollowup != 1)
            view.WriteLine(unit.Name + " reducirá el daño del Follow-Up del rival en un "
                                     + Math.Round((1 - unit.DamageEffects.PercentageReductionOpponentsFollowup) * 100)
                                     + "%");
        if (unit.DamageEffects.AbsolutDamageReduction != 0)
            view.WriteLine(unit.Name + " recibirá " + unit.DamageEffects.AbsolutDamageReduction
                           + " daño en cada ataque");
    }
    
    private static void PrintCombatEffects(View view, Unit unit)
    {
        if (unit.CombatEffects.HpRecuperationAtEveryAttack > 0)
            view.WriteLine(unit.Name + " recuperará HP igual al " + (unit.CombatEffects.HpRecuperationAtEveryAttack * 100) 
                           + "% del daño realizado en cada ataque");
        if (unit.CombatEffects.HasNeutralizationOfCounterattackDenial && unit.CombatEffects.HasCounterAttackDenial)
            view.WriteLine(unit.Name + " neutraliza los efectos que previenen sus contraataques");
        if (unit.CombatEffects.HasGuaranteedFollowUp)
            // todo: revisar esto
            view.WriteLine(unit.Name + " tiene " + unit.CombatEffects.AmountOfEffectsThatGuaranteeFollowup 
                           + " efecto(s) que garantiza(n) su follow up activo(s)");
        if (unit.CombatEffects.HasFollowUpDenial)
            // todo: revisar esto
            view.WriteLine(unit.Name + " tiene " + unit.CombatEffects.AmountOfEffectsThatDenyFollowup 
                           + " efecto(s) que neutraliza(n) su follow up activo(s)");
        if (unit.CombatEffects.HasNeutralizationOfFollowUpDenial)
            view.WriteLine(unit.Name + " es inmune a los efectos que neutralizan su follow up");
        if (unit.CombatEffects.HasDenialOfGuaranteedFollowUp)
            view.WriteLine(unit.Name + " es inmune a los efectos que garantizan su follow up");
        // TODO: VER ORDEN DE ESTE ÚLTIMO
        if (unit.CombatEffects.HasCounterAttackDenial && !unit.CombatEffects.HasNeutralizationOfCounterattackDenial)
            view.WriteLine(unit.Name + " no podrá contraatacar");
        
    }
}