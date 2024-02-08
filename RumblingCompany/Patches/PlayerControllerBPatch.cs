using GameNetcodeStuff;
using HarmonyLib;

namespace RumblingCompany.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch{
        
        [HarmonyPatch(typeof(PlayerControllerB), "DamagePlayer")]
        [HarmonyPostfix]
        private static void OnDamagePatch(int damageNumber){
            Plugin.Mls.LogInfo($"Client was hurt, vibrating");
            Plugin.DeviceManager.increaseVibration(damageNumber / 100f);
        }

        [HarmonyPatch(typeof(PlayerControllerB), "KillPlayer")]
        [HarmonyPostfix]
        private static void OnKilledPatch(ref PlayerControllerB __instance){
            if (__instance != GameNetworkManager.Instance.localPlayerController) return;
            Plugin.Mls.LogInfo($"Client was killed, vibrating");
            Plugin.DeviceManager.increaseVibration(1f);
        }

        [HarmonyPatch(typeof(PlayerControllerB), "Jump_performed")]
        [HarmonyPrefix]
        private static void OnJumpPatch(ref PlayerControllerB __instance, ref bool ___isJumping){
            if (__instance != GameNetworkManager.Instance.localPlayerController) return;
            if (!__instance.thisController.isGrounded || ___isJumping) return;

            Plugin.Mls.LogInfo($"Client jumped, vibrating");
            Plugin.DeviceManager.increaseVibration(0.25f);
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void IsSprintingPatch(ref PlayerControllerB __instance){
            if (__instance != GameNetworkManager.Instance.localPlayerController) return;

            Plugin.DeviceManager.isRunning = __instance.isSprinting;
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void IsUsingJetpackPatch(ref PlayerControllerB __instance){
            if (__instance != GameNetworkManager.Instance.localPlayerController) return;

            Plugin.DeviceManager.isUsingJetpack = __instance.jetpackControls;
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void IsSpectatingPatch(ref PlayerControllerB __instance){
            if (__instance != GameNetworkManager.Instance.localPlayerController) return;

            Plugin.DeviceManager.isSpectating = __instance.hasBegunSpectating;
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void Vibrate(ref PlayerControllerB __instance){
            if (__instance != GameNetworkManager.Instance.localPlayerController) return;

            Plugin.DeviceManager.Vibrate();
        }
    }
}