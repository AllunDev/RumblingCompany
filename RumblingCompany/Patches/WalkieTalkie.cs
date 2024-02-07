using HarmonyLib;

namespace RumblingCompany.Patches
{
    [HarmonyPatch(typeof(WalkieTalkie))]
    internal class WalkieTalkiePatch{
        
        [HarmonyPatch(typeof(WalkieTalkie), "SetLocalClientSpeaking")]
        [HarmonyPostfix]
        private static void UsingWalkieTalkiePatch(bool speaking){
            if (speaking) Plugin.Mls.LogInfo($"Client is using walkie talkie, vibrating");
            Plugin.DeviceManager.isUsingWalkieTalkie = speaking;
        }
    }
}