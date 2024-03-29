using HarmonyLib;

namespace RumblingCompany.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    internal class HUDManagerPatch{
        
        [HarmonyPatch(typeof(HUDManager), "PingScan_performed")]
        [HarmonyPrefix]
        private static void OnPingPatch(ref float ___playerPingingScan){
            if (!Config.VibrateOnScan.Value) return;

            if (___playerPingingScan > -1f) return;
            if (GameNetworkManager.Instance.localPlayerController.isPlayerDead) return;

            Plugin.Mls.LogInfo($"Client scanned, spiking vibration (+ {Config.VibrateOnScanStrength.Value * 100}%)");
            Plugin.DeviceManager.increaseVibration(Config.VibrateOnScanStrength.Value);
        }
    }
}