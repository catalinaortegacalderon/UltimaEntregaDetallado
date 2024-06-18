using System.ComponentModel.Design.Serialization;
using ConsoleApp1.DataTypes;
using ConsoleApp1.EncapsulatedLists;
using ConsoleApp1.SkillsManagement.Skills.AbsolutDamageReductionSkills;
using ConsoleApp1.SkillsManagement.Skills.BaseSkills;
using ConsoleApp1.SkillsManagement.Skills.BonusSkills;
using ConsoleApp1.SkillsManagement.Skills.ExtraDamageSkills;
using ConsoleApp1.SkillsManagement.Skills.HybridSkills;
using ConsoleApp1.SkillsManagement.Skills.NeutralizationSkills;
using ConsoleApp1.SkillsManagement.Skills.PenaltySkills;
using ConsoleApp1.SkillsManagement.Skills.PercentualDamageReductionSkills;
using ConsoleApp1.SkillsManagement.Skills.SkillsThatAffectCombat;
using ConsoleApp1.SkillsManagement.Skills.SkillsThatAffectCombat.CounterattackDenialSkills;
using ConsoleApp1.SkillsManagement.Skills.SkillsThatAffectCombat.DenialOfFollowUpDenialSkills;
using ConsoleApp1.SkillsManagement.Skills.SkillsThatAffectCombat.DenialOfFollowUpGarantizationSkills;
using ConsoleApp1.SkillsManagement.Skills.SkillsThatAffectCombat.FollowUpDenial;
using ConsoleApp1.SkillsManagement.Skills.SkillsThatAffectCombat.HealingSkills;

namespace ConsoleApp1.SkillsManagement;

public class SkillConstructor
{
    public static void Construct(SkillsList skills, string skillString, int skillsCounter)
    {
        if (skillString == "HP +15")
            skills.AddSkill(skillsCounter, new HpPlus15Skill());
        else if (skillString == "Speed +5")
            skills.AddSkill(skillsCounter, new SpeedPlus5Skill());

        else if (skillString == "Resolve")
            skills.AddSkill(skillsCounter, new ResolveSkill());
        else if (skillString == "Armored Blow")
            skills.AddSkill(skillsCounter, new ArmoredBlowSkill());

        else if (skillString == "Fair Fight")
            skills.AddSkill(skillsCounter, new FairFightSkill());
        else if (skillString == "Atk/Def +5")
            skills.AddSkill(skillsCounter, new AtkAndDefPlus5Skill());
        else if (skillString == "Atk/Res +5")
            skills.AddSkill(skillsCounter, new AtkAndResPlus5Skill());
        else if (skillString == "Spd/Res +5")
            skills.AddSkill(skillsCounter, new SpdAndResPlus5Skill());
        else if (skillString == "Attack +6")
            skills.AddSkill(skillsCounter, new AttackPlus6Skill());
        else if (skillString == "Bracing Blow")
            skills.AddSkill(skillsCounter, new BracingBlowSkill());

        else if (skillString == "Will to Win")
            skills.AddSkill(skillsCounter, new WillToWinSkill());
        else if (skillString == "Tome Precision")
            skills.AddSkill(skillsCounter, new TomePrecisionSkill());
        else if (skillString == "Defense +5")
            skills.AddSkill(skillsCounter, new DefensePlus5Skill());
        else if (skillString == "Resistance +5")
            skills.AddSkill(skillsCounter, new ResistancePlus5Skill());
        else if (skillString == "Deadly Blade")
            skills.AddSkill(skillsCounter, new DeadlyBladeSkill());
        else if (skillString == "Death Blow")
            skills.AddSkill(skillsCounter, new DeathBlowSkill());
        else if (skillString == "Darting Blow")
            skills.AddSkill(skillsCounter, new DartingBlowSkill());
        else if (skillString == "Warding Blow")
            skills.AddSkill(skillsCounter, new WardingBlowSkill());
        else if (skillString == "Swift Sparrow")
            skills.AddSkill(skillsCounter, new SwiftSparrowSkill());
        else if (skillString == "Sturdy Blow")
            skills.AddSkill(skillsCounter, new SturdyBlowSkill());
        else if (skillString == "Mirror Strike")
            skills.AddSkill(skillsCounter, new MirrorStrikeSkill());
        else if (skillString == "Steady Blow")
            skills.AddSkill(skillsCounter, new SteadyBlowSkill());
        else if (skillString == "Swift Strike")
            skills.AddSkill(skillsCounter, new SwiftStrikeSkill());
        else if (skillString == "Brazen Atk/Spd")
            skills.AddSkill(skillsCounter, new BrazenAtkSpdSkill());
        else if (skillString == "Brazen Atk/Def")
            skills.AddSkill(skillsCounter, new BrazenAtkDefSkill());
        else if (skillString == "Brazen Atk/Res")
            skills.AddSkill(skillsCounter, new BrazenAtkResSkill());
        else if (skillString == "Brazen Spd/Def")
            skills.AddSkill(skillsCounter, new BrazenSpdDefSkill());
        else if (skillString == "Brazen Spd/Res")
            skills.AddSkill(skillsCounter, new BrazenSpdResSkill());
        else if (skillString == "Brazen Def/Res")
            skills.AddSkill(skillsCounter, new BrazenDefResSkill());
        else if (skillString == "Fire Boost")
            skills.AddSkill(skillsCounter, new FireBoostSkill());
        else if (skillString == "Wind Boost")
            skills.AddSkill(skillsCounter, new WindBoostSkill());
        else if (skillString == "Earth Boost")
            skills.AddSkill(skillsCounter, new EarthBoostSkill());
        else if (skillString == "Water Boost")
            skills.AddSkill(skillsCounter, new WaterBoostSkill());
        else if (skillString == "Chaos Style")
            skills.AddSkill(skillsCounter, new ChaosStyleSkill());
        else if (skillString == "Blinding Flash")
            skills.AddSkill(skillsCounter, new BlindingFlashSkill());
        else if (skillString == "Not *Quite*")
            skills.AddSkill(skillsCounter, new NotQuiteSkill());
        else if (skillString == "Stunning Smile")
            skills.AddSkill(skillsCounter, new StunningSmileSkill());
        else if (skillString == "Disarming Sigh")
            skills.AddSkill(skillsCounter, new DisarmingSighSkill());
        else if (skillString == "Charmer")
            skills.AddSkill(skillsCounter, new CharmerSkill());
        else if (skillString == "Luna")
            skills.AddSkill(skillsCounter, new LunaSkill());
        else if (skillString == "Belief in Love")
            skills.AddSkill(skillsCounter, new BeliefInLoveSkill());
        else if (skillString == "Beorc's Blessing")
            skills.AddSkill(skillsCounter, new BeorcsBlessingSkill());
        else if (skillString == "Agnea's Arrow")
            skills.AddSkill(skillsCounter, new AgneasArrowSkill());
        else if (skillString == "Sword Agility")
            skills.AddSkill(skillsCounter, new AgilitySkill(Weapon.Sword));
        else if (skillString == "Lance Power")
            skills.AddSkill(skillsCounter, new PowerSkill(Weapon.Lance));
        else if (skillString == "Sword Power")
            skills.AddSkill(skillsCounter, new PowerSkill(Weapon.Sword));
        else if (skillString == "Bow Focus")
            skills.AddSkill(skillsCounter, new FocusSkill(Weapon.Bow));
        else if (skillString == "Lance Agility")
            skills.AddSkill(skillsCounter, new AgilitySkill(Weapon.Lance));
        else if (skillString == "Axe Power")
            skills.AddSkill(skillsCounter, new PowerSkill(Weapon.Axe));
        else if (skillString == "Bow Agility")
            skills.AddSkill(skillsCounter, new AgilitySkill(Weapon.Bow));
        else if (skillString == "Sword Focus")
            skills.AddSkill(skillsCounter, new FocusSkill(Weapon.Sword));
        else if (skillString == "Close Def")
            skills.AddSkill(skillsCounter, new CloseDefSkill());
        else if (skillString == "Distant Def")
            skills.AddSkill(skillsCounter, new DistantDefSkill());
        else if (DoesStringContain(skillString, "Lull"))
            skills.AddSkill(skillsCounter, new LullSkill(
                GetStatFromString(skillString, 1),
                GetStatFromString(skillString, 2)));
        else if (DoesStringContain(skillString, "Fort."))
            skills.AddSkill(skillsCounter, new FortSkill(
                GetStatFromString(skillString, 1),
                GetStatFromString(skillString, 2)));
        else if (skillString == "Life and Death")
            skills.AddSkill(skillsCounter, new LifeAndDeathSkill());
        else if (skillString == "Solid Ground")
            skills.AddSkill(skillsCounter, new SolidGroundSkill());
        else if (skillString == "Still Water")
            skills.AddSkill(skillsCounter, new StillWaterSkill());
        else if (skillString == "Dragonskin")
            skills.AddSkill(skillsCounter, new DragonSkinSkill());
        else if (skillString == "Light and Dark")
            skills.AddSkill(skillsCounter, new LightAndDarkSkill());
        else if (skillString == "Single-Minded")
            skills.AddSkill(skillsCounter, new SingleMindedSkill());
        else if (skillString == "Ignis")
            skills.AddSkill(skillsCounter, new IgnisSkill());
        else if (skillString == "Perceptive")
            skills.AddSkill(skillsCounter, new PerceptiveSkill());
        else if (skillString == "Wrath")
            skills.AddSkill(skillsCounter, new WrathSkill());
        else if (skillString == "Soulblade")
            skills.AddSkill(skillsCounter, new SoulbladeSkill());
        else if (skillString == "Sandstorm")
            skills.AddSkill(skillsCounter, new SandstormSkill());
        else if (skillString == "Gentility")
            skills.AddSkill(skillsCounter, new Gentility());
        else if (SkillStringContainsCertainSkillType(skillString, "Guard"))
            CreateGuard(skillString, skillsCounter, skills);
        else if (skillString == "Sympathetic")
            skills.AddSkill(skillsCounter, new Sympathetic());
        else if (skillString == "Arms Shield")
            skills.AddSkill(skillsCounter, new ArmsShield());
        else if (SkillStringContainsCertainSkillType(skillString, "Stance") ||
                 SkillStringContainsCertainSkillType(skillString, "Posture"))
            CreateStance(skillString, skillsCounter, skills);
        else if (skillString == "Dragon Wall")
            skills.AddSkill(skillsCounter, new DragonWallSkill());
        else if (skillString == "Dodge")
            skills.AddSkill(skillsCounter, new DodgeSkill());
        else if (skillString == "Golden Lotus")
            skills.AddSkill(skillsCounter, new GoldenLotusSkill());
        else if (skillString == "Bravery")
            skills.AddSkill(skillsCounter, new BraverySkill());
        else if (skillString == "Back at You")
            skills.AddSkill(skillsCounter, new BackAtYouSkill());
        else if (skillString == "Lunar Brace")
            skills.AddSkill(skillsCounter, new LunarBraceSkill());
        else if (skillString == "Bushido")
            skills.AddSkill(skillsCounter, new BushidoSkill());
        else if (skillString == "Moon-Twin Wing")
            skills.AddSkill(skillsCounter, new MoonTwinWingSkill());
        else if (skillString == "Blue Skies")
            skills.AddSkill(skillsCounter, new BlueSkiesSkill());
        else if (skillString == "Aegis Shield")
            skills.AddSkill(skillsCounter, new AegisShieldSkill());
        else if (skillString == "Remote Sparrow")
            skills.AddSkill(skillsCounter, new RemoteSparrowSkill());
        else if (skillString == "Remote Mirror")
            skills.AddSkill(skillsCounter, new RemoteMirrorSkill());
        else if (skillString == "Remote Sturdy")
            skills.AddSkill(skillsCounter, new RemoteSturdySkill());
        else if (skillString == "Poetic Justice")
            skills.AddSkill(skillsCounter, new PoeticJusticeSkill());
        else if (skillString == "Laguz Friend")
            skills.AddSkill(skillsCounter, new LaguzFriendSkill());
        else if (skillString == "Chivalry")
            skills.AddSkill(skillsCounter, new ChivalrySkill());
        else if (skillString == "Dragon's Wrath")
            skills.AddSkill(skillsCounter, new DragonsWrathSkill());
        else if (skillString == "Prescience")
            skills.AddSkill(skillsCounter, new PrescienceSkill());
        else if (skillString == "Extra Chivalry")
            skills.AddSkill(skillsCounter, new ExtraChivalrySkill());
        else if (skillString == "Guard Bearing")
            skills.AddSkill(skillsCounter, new GuardBearingSkill());
        else if (skillString == "Divine Recreation") 
            skills.AddSkill(skillsCounter, new DivineRecreationSkill());
        else if (skillString == "Quick Riposte")
            skills.AddSkill(skillsCounter, new QuickRiposteSkill());
        else if (skillString == "Follow-Up Ring") 
            skills.AddSkill(skillsCounter, new FollowUpRingSkill());
        else if (skillString == "Sol") 
            skills.AddSkill(skillsCounter, new SolSkill());
        else if (skillString == "Nosferatu") 
            skills.AddSkill(skillsCounter, new NosferatuSkill());
        else if (skillString == "Solar Brace") 
            skills.AddSkill(skillsCounter, new SolarBraceSkill());
        else if (skillString == "Windsweep")
            skills.AddSkill(skillsCounter, new WindsweepSkill());
        else if (skillString == "Surprise Attack")
            skills.AddSkill(skillsCounter, new SurpriseAttackSkill());
        else if (skillString == "Hliðskjálf")
            skills.AddSkill(skillsCounter, new HlioskjalfSkill());
        else if (skillString == "Laws of Sacae")
            skills.AddSkill(skillsCounter, new LawsOfSacae());
        else if (skillString == "Flare")
            skills.AddSkill(skillsCounter, new FlareSkill());
        else if (skillString == "Null C-Disrupt")
            skills.AddSkill(skillsCounter, new NullCDisruptSkill());
        else if (skillString == "Fury")
            skills.AddSkill(skillsCounter, new FurySkill());
        else if (skillString == "Mystic Boost")
            skills.AddSkill(skillsCounter, new MysticBoostSkill());
        else if (skillString == "Mystic Boost")
            skills.AddSkill(skillsCounter, new MysticBoostSkill());
        else if (SkillStringContainsCertainSkillType(skillString, "Push"))
            CreatePush(skillString, skillsCounter, skills);
        else if (skillString == "Scendscale")
            skills.AddSkill(skillsCounter, new ScendscaleSkill());
        else if (skillString == "Eclipse Brace")
            skills.AddSkill(skillsCounter, new EclipseBraceSkill());
        else if (skillString == "Resonance")
            skills.AddSkill(skillsCounter, new ResonanceSkill());
        else if (skillString == "True Dragon Wall")
            skills.AddSkill(skillsCounter, new TrueDragonWallSkill());
        else if (skillString == "Mastermind")
            skills.AddSkill(skillsCounter, new MastermindSkill());
        else if (skillString == "Bewitching Tome")
            skills.AddSkill(skillsCounter, new BewitchingTomeSkill());
        else if (skillString == "Wary Fighter")
            skills.AddSkill(skillsCounter, new WaryFighterSkill());
        else if (skillString == "Piercing Tribute")
            skills.AddSkill(skillsCounter, new PiercingTributeSkill());
        else if (skillString == "Mjölnir")
            skills.AddSkill(skillsCounter, new MjolnirSkill());
        else if (skillString == "Brash Assault")
            skills.AddSkill(skillsCounter, new BrashAssaultSkill());
        else if (skillString == "Null Follow-Up")
            skills.AddSkill(skillsCounter, new NullFollowUpSkill());
        else if (skillString == "Binding Shield")
            skills.AddSkill(skillsCounter, new BindingShieldSkill());
        else if (skillString == "Sun-Twin Wing")
            skills.AddSkill(skillsCounter, new SunTwinWingSkill());
        else if (skillString == "Dragon’s Ire")
            skills.AddSkill(skillsCounter, new DragonsIreSkill());
        else if (skillString == "Black Eagle Rule")
            skills.AddSkill(skillsCounter, new BlackEagleRuleSkill());
        else if (skillString == "Blue Lion Rule")
            skills.AddSkill(skillsCounter, new BlueLionRuleSkill());
        else if (skillString == "New Divinity")
            skills.AddSkill(skillsCounter, new NewDivinitySkill());
        else if (skillString == "Phys. Null Follow")
            skills.AddSkill(skillsCounter, new PhysNullFollowSkill());
        else if (skillString == "Mag. Null Follow")
            skills.AddSkill(skillsCounter, new MagNullFollowSkill());
        else if (SkillStringContainsCertainSkillType(skillString, "Impact"))
            CreateImpact(skillString, skillsCounter, skills);
        else if (SkillStringContainsCertainSkillType(skillString, "Breaker"))
            CreateBreaker(skillString, skillsCounter, skills);
        else if (SkillStringContainsCertainSkillType(skillString, "Flight"))
            CreateFlight(skillString, skillsCounter, skills);
        else if (skillString == "Slick Fighter")
            skills.AddSkill(skillsCounter, new SlickFighterSkill());
        else if (skillString == "Wily Fighter")
            skills.AddSkill(skillsCounter, new WilyFighterSkill());
        else if (skillString == "Savvy Fighter")
            skills.AddSkill(skillsCounter, new SavyFighterSkill());
        else if (skillString == "Flow Force")
                    skills.AddSkill(skillsCounter, new FlowForceSkill());
        else if (skillString == "Flow Refresh")
            skills.AddSkill(skillsCounter, new FlowRefreshSkill());
        else if (skillString == "Flow Feather")
            skills.AddSkill(skillsCounter, new FlowFeatherSkill());
        
    }

    private static bool SkillStringContainsCertainSkillType(string skillString, string name)
    {
        return skillString.Split(" ").Length >= 2 && skillString.Split(" ")[1] == name;
    }

    private static StatType GetStatFromString(string skillString, int statNumber)
    {
        var statAsString = skillString.Split(new[] { ' ', '/' },
            StringSplitOptions.RemoveEmptyEntries)[statNumber];
        return ConvertStatStringToStatType(statAsString);
    }

    private static bool DoesStringContain(string skillString, string skillName)
    {
        return skillString.Split(new[] { ' ', '/' },
            StringSplitOptions.RemoveEmptyEntries)[0] == skillName;
    }

    private static void CreateStance(string skillString, int skillsCounter, SkillsList skills)
    {
        if (IsStanceType(skillString, "Fierce"))
            skills.AddSkill(skillsCounter, new StanceSkill(StatType.Atk,
                StatType.None, 8, 0));

        if (IsStanceType(skillString, "Darting"))
            skills.AddSkill(skillsCounter, new StanceSkill(StatType.Spd,
                StatType.None, 8, 0));

        if (IsStanceType(skillString, "Steady"))
            skills.AddSkill(skillsCounter, new StanceSkill(StatType.Def,
                StatType.None, 8, 0));

        if (IsStanceType(skillString, "Warding"))
            skills.AddSkill(skillsCounter, new StanceSkill(StatType.Res,
                StatType.None, 8, 0));

        if (IsStanceType(skillString, "Kestrel"))
            skills.AddSkill(skillsCounter, new StanceSkill(StatType.Atk,
                StatType.Spd, 6, 6));

        if (IsStanceType(skillString, "Sturdy"))
            skills.AddSkill(skillsCounter, new StanceSkill(StatType.Atk,
                StatType.Def, 6, 6));

        if (IsStanceType(skillString, "Mirror"))
            skills.AddSkill(skillsCounter, new StanceSkill(StatType.Atk,
                StatType.Res, 6, 6));

        if (IsSteadyPosture(skillString))
            skills.AddSkill(skillsCounter, new StanceSkill(StatType.Spd,
                StatType.Def, 6, 6));

        if (IsStanceType(skillString, "Swift"))
            skills.AddSkill(skillsCounter, new StanceSkill(StatType.Spd,
                StatType.Res, 6, 6));

        if (IsStanceType(skillString, "Bracing"))
            skills.AddSkill(skillsCounter, new StanceSkill(StatType.Def,
                StatType.Res, 6, 6));
    }

    private static bool IsSteadyPosture(string skillString)
    {
        return skillString.Split(" ")[0] == "Steady" && skillString.Split(" ")[1] == "Posture";
    }

    private static bool IsStanceType(string skillString, string type)
    {
        return skillString.Split(" ")[0] == type && skillString.Split(" ")[1] == "Stance";
    }

    private static void CreateGuard(string skillString, int skillsCounter, SkillsList skills)
    {
        // todo: arreglar esto, tengo convertidor para stat pero no para weapon
        
        var weapon = Weapon.Empty;
        var weaponString = skillString.Split(" ")[0];
        weapon = weaponString switch
        {
            "Magic" => Weapon.Magic,
            "Axe" => Weapon.Axe,
            "Lance" => Weapon.Lance,
            "Bow" => Weapon.Bow,
            "Sword" => Weapon.Sword,
            _ => weapon
        };
        skills.AddSkill(skillsCounter, new Guard(weapon));
    }
    
    private static void CreateImpact(string skillString, int skillsCounter, SkillsList skills)
    {
        var impactType = skillString.Split(" ")[0];
        Skill skill = new EmptySkill();

        switch (impactType)
        {
            case "Sturdy":
                skill = new ImpactSkill(StatType.Atk, StatType.Def);
                break;
            case "Mirror":
                skill = new ImpactSkill(StatType.Atk, StatType.Res);
                break;
            case "Swift":
                skill = new ImpactSkill(StatType.Spd, StatType.Res);
                break;
            case "Steady":
                skill = new ImpactSkill(StatType.Spd, StatType.Def);
                break;
        }

        skills.AddSkill(skillsCounter, skill);
    }
    
    private static void CreateBreaker(string skillString, int skillsCounter, SkillsList skills)
    {
        var impactType = skillString.Split(" ")[0];
        Skill skill = new EmptySkill();

        switch (impactType)
        {
            case "Melee":
                skill = new BreakerSkill([Weapon.Sword, Weapon.Lance, Weapon.Axe]);
                break;
            case "Range":
                skill = new BreakerSkill([Weapon.Magic, Weapon.Bow]);
                break;
        }

        skills.AddSkill(skillsCounter, skill);
    }
    
    // todo: arreglar orden
    
    private static void CreateFlight(string skillString, int skillsCounter, SkillsList skills)
    {
        var flightType = skillString.Split(" ")[0];
        Skill skill = new EmptySkill();

        switch (flightType)
        {
            case "Pegasus":
                skill = new FlightSkill(StatType.Res);
                break;
            case "Wyvern":
                skill = new FlightSkill(StatType.Def);
                break;
        }
        
        skills.AddSkill(skillsCounter, skill);
    }

    private static void CreatePush(string skillString, int skillsCounter, SkillsList skills)
    {
        var firstStat = GetStatFromString(skillString, 0);
        var secondSatat = GetStatFromString(skillString, 1);
        skills.AddSkill(skillsCounter, new PushSkill(firstStat, secondSatat));
    }

    private static StatType ConvertStatStringToStatType(string statString)
    {
        var stat = StatType.None;
        if (statString == "Atk")
            stat = StatType.Atk;
        else if (statString == "Res")
            stat = StatType.Res;
        else if (statString == "Def")
            stat = StatType.Def;
        else if (statString == "Spd") stat = StatType.Spd;
        return stat;
    }
}