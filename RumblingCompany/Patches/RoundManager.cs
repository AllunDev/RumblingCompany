using HarmonyLib;

namespace RumblingCompany.Patches
{
    [HarmonyPatch(typeof(RoundManager))]
    internal class RoundManagerPatch
    {
        [HarmonyPatch(typeof(RoundManager), "CollectNewScrapForThisRound")]
        [HarmonyPostfix]
        private static void CollectNewScrapForThisRoundPatch(){
            
            Plugin.Mls.LogInfo($"Client collected scrap, vibrating");
            Plugin.DeviceManager.increaseVibration(0.25f);
        }
    }
}