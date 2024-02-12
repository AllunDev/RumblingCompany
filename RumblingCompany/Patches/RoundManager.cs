using HarmonyLib;

namespace RumblingCompany.Patches
{
    [HarmonyPatch(typeof(RoundManager))]
    internal class RoundManagerPatch
    {
        [HarmonyPatch(typeof(RoundManager), "CollectNewScrapForThisRound")]
        [HarmonyPrefix]
        private static void CollectNewScrapForThisRoundPatch(GrabbableObject scrapObject){
            if (!Config.CollectionEnabled.Value) return;

            if (scrapObject.playerHeldBy != GameNetworkManager.Instance.localPlayerController) return;
            
            if (RoundManager.Instance.scrapCollectedThisRound.Contains(scrapObject) || scrapObject.scrapPersistedThroughRounds) return;

            Plugin.Mls.LogInfo($"Client collected scrap, spiking vibration (+ {Config.CollectionStrength.Value * 100}%)");
            Plugin.DeviceManager.increaseVibration(Config.CollectionStrength.Value);
        }
    }
}