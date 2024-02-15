using BepInEx;
using BepInEx.Configuration;

namespace RumblingCompany
{
    internal class Config{
        private static ConfigFile ConfigFile { get; set; }

        #region General
        internal static ConfigEntry<string> IntifaceServerAdress { get; set; }
        internal static ConfigEntry<float> VibrationIncreasePerSecond { get; set; }
        internal static ConfigEntry<float> VibrationDecreasePerSecond { get; set; }
        internal static ConfigEntry<bool> EnableDebugging { get; set; }
        #endregion

        #region Punishment
        internal static ConfigEntry<bool> VibrateOnDeath { get; set; }
        internal static ConfigEntry<float> VibrateOnDeathStrength { get; set; }
        internal static ConfigEntry<bool> VibrateOnTakingDamage { get; set; }
        internal static ConfigEntry<bool> VibrateOnSpectate { get; set; }
        internal static ConfigEntry<float> VibrateOnSpectateStrength { get; set; }
        internal static ConfigEntry<bool> VibrateOnBeingZapped { get; set; }
        internal static ConfigEntry<float> VibrateOnBeingZappedStrength { get; set; }
        #endregion

        #region Reward
        internal static ConfigEntry<bool> VibrateOnKill { get; set; }
        internal static ConfigEntry<float> VibrateOnKillStrength { get; set; }
        internal static ConfigEntry<bool> VibrateOnDealingDamage { get; set; }
        internal static ConfigEntry<float> VibrateOnDealingDamageStrength { get; set; }
        internal static ConfigEntry<bool> VibrateOnZapping { get; set; }
        internal static ConfigEntry<float> VibrateOnZappingStrength { get; set; }
        internal static ConfigEntry<bool> VibrateOnCollect { get; set; }
        internal static ConfigEntry<float> VibrateOnCollectStrength { get; set; }
        #endregion

        #region Miscellaneous
        internal static ConfigEntry<bool> VibrateOnSprint { get; set; }
        internal static ConfigEntry<float> VibrateOnSprintStrength { get; set; }
        internal static ConfigEntry<bool> VibrateOnJump { get; set; }
        internal static ConfigEntry<float> VibrateOnJumpStrength { get; set; }
        internal static ConfigEntry<bool> VibrateOnScan { get; set; }
        internal static ConfigEntry<float> VibrateOnScanStrength { get; set; }
        internal static ConfigEntry<bool> VibrateOnUsingWalkieTalkie { get; set; }
        internal static ConfigEntry<float> VibrateOnUsingWalkieTalkieStrength { get; set; }
        internal static ConfigEntry<bool> VibrateOnReceivingWalkieTalkie { get; set; }
        internal static ConfigEntry<float> VibrateOnReceivingWalkieTalkieStrength { get; set; }
        internal static ConfigEntry<bool> VibrateOnItemCharge { get; set; }
        internal static ConfigEntry<float> VibrateOnItemChargeStrength { get; set; }
        internal static ConfigEntry<bool> VibrateOnJetpack { get; set; }
        internal static ConfigEntry<float> VibrateOnJetpackStrength { get; set; }
        #endregion

        static Config()
        {
            ConfigFile = new ConfigFile(Paths.ConfigPath + "\\RumblingCompany.cfg", true);

            #region General
            IntifaceServerAdress = ConfigFile.Bind(
                "1 General",
                "Server Adress",
                "ws://localhost:12345",
                "Intiface server adress."
            );
            VibrationIncreasePerSecond = ConfigFile.Bind("1 General", "Vibration Increase Per Second", 2f, "How fast vibrations increase.");
            VibrationDecreasePerSecond = ConfigFile.Bind("1 General", "Vibration Decrease Per Second", 0.25f, "How fast vibrations decrease.");
            EnableDebugging = ConfigFile.Bind("1 General", "Enable Debugging", false, "Enable debugging. (!!Console spam!!)");
            #endregion

            #region Punishment
            VibrateOnDeath = ConfigFile.Bind("2 Punishment", "Vibrate on Death", true, "Vibrate when the player is killed.");
            VibrateOnDeathStrength = ConfigFile.Bind("2 Punishment", "Vibrate on Death Intensity", 1f, "Vibration increase when the player is killed. [0 = no vibrations, 1 = jump to max power]");

            VibrateOnTakingDamage = ConfigFile.Bind("2 Punishment", "Vibrate on Taking Damage", true, "Vibrate when the player takes damage. [Intensity determined by damage taken]");

            VibrateOnSpectate = ConfigFile.Bind("2 Punishment", "Vibrate while Spectating", false, "Vibrate while spectating other players.");
            VibrateOnSpectateStrength = ConfigFile.Bind("2 Punishment", "Vibrate while Spectating Intensity", 0.2f, "Vibration intensity while spectating.");

            VibrateOnBeingZapped = ConfigFile.Bind("2 Punishment", "Vibrate on Being Zapped", true, "Vibrate while being zapped by a zap gun.");
            VibrateOnBeingZappedStrength = ConfigFile.Bind("2 Punishment", "Vibrate on Being Zapped Intensity", 0.8f, "Intensity of vibrations while being zapped by a zap gun.");
            #endregion

            #region Reward
            VibrateOnKill = ConfigFile.Bind("3 Reward", "Vibrate On Kill", true, "Vibrate when the player kills an enemy.");
            VibrateOnKillStrength = ConfigFile.Bind("3 Reward", "Vibrate on Kill Intensity", 0.8f, "Vibration increase on killing an enemy.");

            VibrateOnDealingDamage = ConfigFile.Bind("3 Reward", "Vibrate on Dealing Damage", true, "Vibrate on dealing damage to enemies");
            VibrateOnDealingDamageStrength = ConfigFile.Bind("3 Reward", "Vibrate on Dealing Damage Intensity", 0.2f, "Vibration intensity from damaging enemies");

            VibrateOnZapping = ConfigFile.Bind("3 Reward", "Vibrate on Zapping", true, "Vibrate while firing the Zap gun");
            VibrateOnZappingStrength = ConfigFile.Bind("3 Reward", "Vibrate on Zapping Intensity", 0.5f, "Vibration intensity while firing the Zap gun");

            VibrateOnCollect = ConfigFile.Bind("3 Reward", "Vibrate on Collecting Scrap", true, "Vibrate when depositing scrap in the ship");
            VibrateOnCollectStrength = ConfigFile.Bind("3 Reward", "Vibrate on Collecting Scrap Intensity", 0.5f, "Vibration intensity of depositing scrap");
            #endregion

            #region Miscellaneous
            VibrateOnSprint = ConfigFile.Bind("4 Miscellaneous", "Vibrate on Sprint", true, "Vibrate while running");
            VibrateOnSprintStrength = ConfigFile.Bind("4 Miscellaneous", "Vibrate on sprint Intensity", 0.2f, "Vibration intensity while running");

            VibrateOnJump = ConfigFile.Bind("4 Miscellaneous", "Vibrate on Jump", true, "Vibrate on jumping");
            VibrateOnJumpStrength = ConfigFile.Bind("4 Miscellaneous", "Vibrate on Jump Intensity", 0.25f, "Vibration increase on jump");
            
            VibrateOnScan = ConfigFile.Bind("4 Miscellaneous", "Vibrate on Scan", true, "Vibrate when the scanning for objects");
            VibrateOnScanStrength = ConfigFile.Bind("4 Miscellaneous", "Vibrate on Scan Intensity", 0.2f, "Vibration intensity from scanning");
            
            VibrateOnUsingWalkieTalkie = ConfigFile.Bind("4 Miscellaneous", "Vibrate on Using Walkie Talkie", true, "Vibrate while using the walkie talkie");
            VibrateOnUsingWalkieTalkieStrength = ConfigFile.Bind("4 Miscellaneous", "Vibrate on Using Walkie Talkie Intensity", 0.3f, "Vibration intensity while using the walkie talkie");
            
            VibrateOnReceivingWalkieTalkie = ConfigFile.Bind("4 Miscellaneous", "Vibrate on Receiving Walkie Talkie", true, "Vibrate while receiving transmissions from the walkie talkie");
            VibrateOnReceivingWalkieTalkieStrength = ConfigFile.Bind("4 Miscellaneous", "Vibrate on Receiving Walkie Talkie Intensity", 0.25f, "Vibration intensity while receiving transmissions from the walkie talkie");
            
            VibrateOnItemCharge = ConfigFile.Bind("4 Miscellaneous", "Vibrate on Item Charge", true, "Vibrate when charging items");
            VibrateOnItemChargeStrength = ConfigFile.Bind("4 Miscellaneous", "Vibrate on Item Charge Intensity", 0.8f, "Vibration intensity from charging items");
            
            VibrateOnJetpack = ConfigFile.Bind("4 Miscellaneous", "Vibrate on Jetpack", true, "Vibrate while using the jetpack");
            VibrateOnJetpackStrength = ConfigFile.Bind("4 Miscellaneous", "Vibrate on Jetpack Intensity", 0.5f, "Vibration intensity while using the jetpack");
            #endregion
        }
    }
}