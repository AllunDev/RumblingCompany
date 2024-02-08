using System.Reflection;
using HarmonyLib;

namespace RumblingCompany.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    internal class HUDManagerPatch{
        
        [HarmonyPatch(typeof(HUDManager), "PingScan_performed")]
        [HarmonyPrefix]
        private static void OnPingPatch(ref float ___playerPingingScan){
            if (___playerPingingScan > -1f) return;
            if (GameNetworkManager.Instance.localPlayerController.isPlayerDead) return;

            Plugin.Mls.LogInfo($"Client scanned, vibrating");
            Plugin.DeviceManager.increaseVibration(0.2f);
        }
    }
}