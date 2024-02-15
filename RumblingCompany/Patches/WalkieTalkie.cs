using HarmonyLib;
using System.Collections.Generic;

namespace RumblingCompany.Patches
{
    [HarmonyPatch(typeof(WalkieTalkie))]
    internal class WalkieTalkiePatch{
        
        [HarmonyPatch(typeof(WalkieTalkie), "SetLocalClientSpeaking")]
        [HarmonyPostfix]
        private static void UsingWalkieTalkiePatch(bool speaking){
            if (!Config.VibrateOnUsingWalkieTalkie.Value) return;
            
            // if (speaking) Plugin.Mls.LogInfo($"Client is using walkie talkie, vibrating");
            Plugin.DeviceManager.isUsingWalkieTalkie = speaking;
        }


        [HarmonyPatch(typeof(WalkieTalkie), "Update")]
        [HarmonyPostfix]
        private static void RecievingWalkieTalkiePatch(ref WalkieTalkie __instance, ref List<WalkieTalkie> ___allWalkieTalkies){
            if (!Config.VibrateOnReceivingWalkieTalkie.Value) return;

            if (!GameNetworkManager.Instance.localPlayerController.holdingWalkieTalkie) return;
            if (GameNetworkManager.Instance.localPlayerController != __instance.playerHeldBy) return;

            foreach (var walkieTalkie in ___allWalkieTalkies)
            {
                if (walkieTalkie.isBeingUsed && walkieTalkie != __instance && walkieTalkie.clientIsHoldingAndSpeakingIntoThis)
                {
                    Plugin.DeviceManager.isRecievingWalkieTalkie = true;

                    return;
                }
            }

            Plugin.DeviceManager.isRecievingWalkieTalkie = false;
        }

    }
}