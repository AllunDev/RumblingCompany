using HarmonyLib;

namespace RumblingCompany.Patches
{
    [HarmonyPatch(typeof(ItemCharger))]
    internal class ItemChargerPatch{
        
        [HarmonyPatch(typeof(ItemCharger), "ChargeItem")]
        [HarmonyPostfix]
        private static void OnItemChargePatch(){
            Plugin.Mls.LogInfo($"Client charged item, vibrating");
            Plugin.DeviceManager.increaseVibration(0.5f);
        }
    }
}