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


        /***    Couldn't get this to work, will do something simpler and come back here later    ***/

        // [HarmonyPatch(typeof(WalkieTalkie), "EnableWalkieTalkieListening")]
        // [HarmonyPostfix]
        // private static void RecievingWalkieTalkiePatch(){
        //     // if (otherClientIsTransmittingAudios == null){
        //     //     Plugin.DeviceManager.isRecievingWalkieTalkie = false;
        //     //     return;   
        //     // }

        //     Plugin.Mls.LogInfo($"Client is recieving walkie talkie, vibrating");

        //     // Plugin.DeviceManager.isRecievingWalkieTalkie = ___otherClientIsTransmittingAudios;
        // }
    }
}