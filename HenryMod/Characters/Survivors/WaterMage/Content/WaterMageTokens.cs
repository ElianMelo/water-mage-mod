using System;
using WaterMage.Modules;
using WaterMage.Survivors.WaterMage.Achievements;

namespace WaterMage.Survivors.WaterMage
{
    public static class WaterMageTokens
    {
        public static void Init()
        {
            AddWaterMageTokens();

            ////uncomment this to spit out a lanuage file with all the above tokens that people can translate
            ////make sure you set Language.usingLanguageFolder and printingEnabled to true
            //Language.PrintOutput("WaterMage.txt");
            ////refer to guide on how to build and distribute your mod with the proper folders
        }

        public static void AddWaterMageTokens()
        {
            string prefix = WaterMageSurvivor.WaterMage_PREFIX;

            string desc = "WaterMage is a skilled fighter who makes use of a wide arsenal of weaponry to take down his foes.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine
             + "< ! > Sword is a good all-rounder while Boxing Gloves are better for laying a beatdown on more powerful foes." + Environment.NewLine + Environment.NewLine
             + "< ! > Pistol is a powerful anti air, with its low cooldown and high damage." + Environment.NewLine + Environment.NewLine
             + "< ! > Roll has a lingering armor buff that helps to use it aggressively." + Environment.NewLine + Environment.NewLine
             + "< ! > Bomb can be used to wipe crowds with ease." + Environment.NewLine + Environment.NewLine;

            string outro = "..and so he left, searching for a new identity.";
            string outroFailure = "..and so he vanished, forever a blank slate.";

            Language.Add(prefix + "NAME", "WaterMage");
            Language.Add(prefix + "DESCRIPTION", desc);
            Language.Add(prefix + "SUBTITLE", "The Chosen One");
            Language.Add(prefix + "LORE", "sample lore");
            Language.Add(prefix + "OUTRO_FLAVOR", outro);
            Language.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            Language.Add(prefix + "MASTERY_SKIN_NAME", "Alternate");
            #endregion

            #region Passive
            Language.Add(prefix + "PASSIVE_NAME", "WaterMage passive");
            Language.Add(prefix + "PASSIVE_DESCRIPTION", "Sample text.");
            #endregion

            #region Primary
            Language.Add(prefix + "PRIMARY_SLASH_NAME", "Sword");
            Language.Add(prefix + "PRIMARY_SLASH_DESCRIPTION", Tokens.agilePrefix + $"Swing forward for <style=cIsDamage>{100f * WaterMageStaticValues.swordDamageCoefficient}% damage</style>.");

            Language.Add(prefix + "PRIMARY_SPLASH_NAME", "Tidal Blades");
            Language.Add(prefix + "PRIMARY_SPLASH_DESCRIPTION", Tokens.agilePrefix + $"Deliver a sweeping double slash of water from right to left. for <style=cIsDamage>{100f * WaterMageStaticValues.swordDamageCoefficient}% damage</style>.");
            #endregion

            #region Secondary
            Language.Add(prefix + "SECONDARY_GUN_NAME", "Handgun");
            Language.Add(prefix + "SECONDARY_GUN_DESCRIPTION", Tokens.agilePrefix + $"Fire a handgun for <style=cIsDamage>{100f * WaterMageStaticValues.gunDamageCoefficient}% damage</style>.");

            Language.Add(prefix + "SECONDARY_WATER_NAME", "Water Barrage");
            Language.Add(prefix + "SECONDARY_WATER_DESCRIPTION", Tokens.agilePrefix + $"Unleash a rapid stream of water projectiles to overwhelm foes. for <style=cIsDamage>{100f * WaterMageStaticValues.gunDamageCoefficient}% damage</style>.");
            #endregion

            #region Utility
            Language.Add(prefix + "UTILITY_ROLL_NAME", "Roll");
            Language.Add(prefix + "UTILITY_ROLL_DESCRIPTION", "Roll a short distance, gaining <style=cIsUtility>300 armor</style>. <style=cIsUtility>You cannot be hit during the roll.</style>");

            Language.Add(prefix + "UTILITY_DASH_NAME", "Glacial Dash");
            Language.Add(prefix + "UTILITY_DASH_DESCRIPTION", "Dash forward, leaving an ice pillar in your wake to damage enemies, gaining <style=cIsUtility>300 armor</style>. <style=cIsUtility>You cannot be hit during the roll.</style>");
            #endregion

            #region Special
            Language.Add(prefix + "SPECIAL_BOMB_NAME", "Bomb");
            Language.Add(prefix + "SPECIAL_BOMB_DESCRIPTION", $"Throw a bomb for <style=cIsDamage>{100f * WaterMageStaticValues.bombDamageCoefficient}% damage</style>.");

            Language.Add(prefix + "SPECIAL_ORB_NAME", "Orb");
            Language.Add(prefix + "SPECIAL_ORB_DESCRIPTION", $"Throw a orb for <style=cIsDamage>{100f * WaterMageStaticValues.orbDamageCoefficient}% damage</style>.");
            #endregion

            #region Achievements
            Language.Add(Tokens.GetAchievementNameToken(WaterMageMasteryAchievement.identifier), "WaterMage: Mastery");
            Language.Add(Tokens.GetAchievementDescriptionToken(WaterMageMasteryAchievement.identifier), "As WaterMage, beat the game or obliterate on Monsoon.");
            #endregion
        }
    }
}
