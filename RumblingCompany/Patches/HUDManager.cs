using HarmonyLib;

namespace RumblingCompany.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    internal class HUDManagerPatch{
        
        [HarmonyPatch(typeof(HUDManager), "PingScan_performed")]
        [HarmonyPostfix]
        private static void OnPingPatch(){
            Plugin.Mls.LogInfo($"Client scanned, vibrating");
            Plugin.DeviceManager.increaseVibration(0.2f);
        }
    }
}