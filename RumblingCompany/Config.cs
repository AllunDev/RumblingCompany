using BepInEx;
using BepInEx.Configuration;

namespace RumblingCompany
{
    internal class Config{
        private static ConfigFile ConfigFile { get; set; }

        internal static ConfigEntry<string> ServerAdress { get; set; }
        internal static ConfigEntry<float> VibrationIncreasePerSecond { get; set; }
        internal static ConfigEntry<float> VibrationDecreasePerSecond { get; set; }

        internal static ConfigEntry<bool> DiedEnabled { get; set; }
        internal static ConfigEntry<float> DiedStrength { get; set; }
        internal static ConfigEntry<bool> HurtEnabled { get; set; }
        internal static ConfigEntry<bool> SpectatingEnabled { get; set; }
        internal static ConfigEntry<float> SpectatingStrength { get; set; }
        internal static ConfigEntry<bool> BeingZappedEnabled { get; set; }
        internal static ConfigEntry<float> BeingZappedStrength { get; set; }

        internal static ConfigEntry<bool> KillingEnabled { get; set; }
        internal static ConfigEntry<float> KillingStrength { get; set; }
        internal static ConfigEntry<bool> DealingDamageEnabled { get; set; }
        internal static ConfigEntry<float> DealingDamageStrength { get; set; }
        internal static ConfigEntry<bool> ZappingEnabled { get; set; }
        internal static ConfigEntry<float> ZappingStrength { get; set; }
        internal static ConfigEntry<bool> CollectionEnabled { get; set; }
        internal static ConfigEntry<float> CollectionStrength { get; set; }

        internal static ConfigEntry<bool> RunningEnabled { get; set; }
        internal static ConfigEntry<float> RunningStrength { get; set; }
        internal static ConfigEntry<bool> JumpingEnabled { get; set; }
        internal static ConfigEntry<float> JumpingStrength { get; set; }
        internal static ConfigEntry<bool> ScanningEnabled { get; set; }
        internal static ConfigEntry<float> ScanningStrength { get; set; }
        internal static ConfigEntry<bool> UsingWalkieTalkieEnabled { get; set; }
        internal static ConfigEntry<float> UsingWalkieTalkieStrength { get; set; }
        internal static ConfigEntry<bool> ReceivingWalkieTalkieEnabled { get; set; }
        internal static ConfigEntry<float> ReceivingWalkieTalkieStrength { get; set; }
        internal static ConfigEntry<bool> ChargingItemEnabled { get; set; }
        internal static ConfigEntry<float> ChargingItemStrength { get; set; }
        internal static ConfigEntry<bool> JetpackEnabled { get; set; }
        internal static ConfigEntry<float> JetpackStrength { get; set; }

        static Config()
        {
            ConfigFile = new ConfigFile(Paths.ConfigPath + "\\RumblingCompany.cfg", true);

             #region General
            ServerAdress = ConfigFile.Bind(
                "1.General",
                "Server Adress",
                "ws://localhost:12345",
                "Intiface server adress."
            );
            VibrationIncreasePerSecond = ConfigFile.Bind("1.General.Increase", "Strength", 2f, "How fast vibrations increase");
            VibrationDecreasePerSecond = ConfigFile.Bind("1.General.Decrease", "Strength", 0.25f, "How fast vibrations decrease");
            #endregion

            #region Punishment
            DiedEnabled = ConfigFile.Bind("2.Punishment.Died", "Enabled", true, "Vibrate when killed");
            DiedStrength = ConfigFile.Bind("2.Punishment.Died", "Strength", 1f, "Intensity of vibrations when you are killed");

            HurtEnabled = ConfigFile.Bind("2.Punishment.WasHurt", "Enabled", true, "Vibrate when hurt (Intensity based on damage taken)");

            SpectatingEnabled = ConfigFile.Bind("2.Punishment.Spectating", "Enabled", false, "Vibrate when spectating other players");
            SpectatingStrength = ConfigFile.Bind("2.Punishment.Spectating", "Strength", 0.2f, "Intensity of vibrations while spectating");

            BeingZappedEnabled = ConfigFile.Bind("2.Punishment.Zapped", "Enabled", true, "Vibrate when being zapped");
            BeingZappedStrength = ConfigFile.Bind("2.Punishment.Zapped", "Strength", 0.8f, "Intensity of vibrations while being zapped by the Zap Gun");
            #endregion


            #region Reward
            KillingEnabled = ConfigFile.Bind("3.Reward.Killed", "Enabled", true, "Vibrate when killing");
            KillingStrength = ConfigFile.Bind("3.Reward.Killed", "Strength", 0.8f, "Intensity of vibrations from killing others");

            DealingDamageEnabled = ConfigFile.Bind("3.Reward.DealtDamage", "Enabled", true, "Vibrate on dealing damage");
            DealingDamageStrength = ConfigFile.Bind("3.Reward.DealtDamage", "Strength", 0.2f, "Intensity of vibrations from dealing damage to others");

            ZappingEnabled = ConfigFile.Bind("3.Reward.Zapping", "Enabled", true, "Vibrate when zapping");
            ZappingStrength = ConfigFile.Bind("3.Reward.Zapping", "Strength", 0.5f, "Intensity of vibrations while zapping others with the Zap Gun");

            CollectionEnabled = ConfigFile.Bind("3.Reward.CollectedScrap", "Enabled", true, "Vibrate when collecting scrap");
            CollectionStrength = ConfigFile.Bind("3.Reward.CollectedScrap", "Strength", 0.5f, "Intensity of vibrations from collecting scrap");
            #endregion


            #region Miscellaneous
            RunningEnabled = ConfigFile.Bind("4.Miscellaneous.Running", "Enabled", true, "Vibrate while running");
            RunningStrength = ConfigFile.Bind("4.Miscellaneous.Running", "Strength", 0.2f, "Vibration intensity while running");

            JumpingEnabled = ConfigFile.Bind("4.Miscellaneous.Jumping", "Enabled", true, "Vibrate when jumping");
            JumpingStrength = ConfigFile.Bind("4.Miscellaneous.Jumping", "Strength", 0.25f, "Vibration intensity from jumping");
            
            ScanningEnabled = ConfigFile.Bind("4.Miscellaneous.Scanning", "Enabled", true, "Vibrate when scanning");
            ScanningStrength = ConfigFile.Bind("4.Miscellaneous.Scanning", "Strength", 0.2f, "Vibration intensity from scanning");
            
            UsingWalkieTalkieEnabled = ConfigFile.Bind("4.Miscellaneous.UsingTheWalkieTalkie", "Enabled", true, "Vibrate while using the walkie talkie");
            UsingWalkieTalkieStrength = ConfigFile.Bind("4.Miscellaneous.UsingTheWalkieTalkie", "Strength", 0.3f, "Vibration intensity while using the walkie talkie");
            
            ReceivingWalkieTalkieEnabled = ConfigFile.Bind("4.Miscellaneous.RecievingWalkieTalkieTransmition", "Enabled", true, "Vibrate while receiving audio from the walkie talkie");
            ReceivingWalkieTalkieStrength = ConfigFile.Bind("4.Miscellaneous.RecievingWalkieTalkieTransmition", "Strength", 0.25f, "Vibration intensity while receiving audio from the walkie talkie");
            
            ChargingItemEnabled = ConfigFile.Bind("4.Miscellaneous.CharingItem", "Enabled", true, "Vibrate when charging items");
            ChargingItemStrength = ConfigFile.Bind("4.Miscellaneous.CharingItem", "Strength", 0.8f, "Vibration intensity from charting items");
            
            JetpackEnabled = ConfigFile.Bind("4.Miscellaneous.Jetpack", "Enabled", true, "Vibrate while jetpacking");
            JetpackStrength = ConfigFile.Bind("4.Miscellaneous.Jetpack", "Strength", 0.5f, "Vibration intensity while using the jetpack");
            #endregion
        }
    }
}