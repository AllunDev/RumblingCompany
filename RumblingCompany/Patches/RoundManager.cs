using HarmonyLib;

namespace RumblingCompany.Patches
{
    [HarmonyPatch(typeof(RoundManager))]
    internal class RoundManagerPatch
    {
        [HarmonyPatch(typeof(RoundManager), "CollectNewScrapForThisRound")]
        [HarmonyPrefix]
        private static void CollectNewScrapForThisRoundPatch(GrabbableObject scrapObject){
            if (scrapObject.playerHeldBy != GameNetworkManager.Instance.localPlayerController) return;
            
            if (RoundManager.Instance.scrapCollectedThisRound.Contains(scrapObject) || scrapObject.scrapPersistedThroughRounds) return;

            Plugin.Mls.LogInfo($"Client collected scrap, vibrating");
            Plugin.DeviceManager.increaseVibration(0.25f);
        }
    }
}