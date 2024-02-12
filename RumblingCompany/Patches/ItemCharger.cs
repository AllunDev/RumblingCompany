using HarmonyLib;

namespace RumblingCompany.Patches
{
    [HarmonyPatch(typeof(ItemCharger))]
    internal class ItemChargerPatch{
        
        [HarmonyPatch(typeof(ItemCharger), "ChargeItem")]
        [HarmonyPostfix]
        private static void OnItemChargePatch(){
            if (!Config.ChargingItemEnabled.Value) return;

            Plugin.Mls.LogInfo($"Client charged an item, spiking vibration (+ {Config.ChargingItemStrength.Value * 100}%)");
            Plugin.DeviceManager.increaseVibration(Config.ChargingItemStrength.Value);
        }
    }
}



            