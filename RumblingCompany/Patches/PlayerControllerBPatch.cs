using GameNetcodeStuff;
using HarmonyLib;

namespace RumblingCompany.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch{
        
        [HarmonyPatch(typeof(PlayerControllerB), "DamagePlayer")]
        [HarmonyPostfix]
        private static void OnDamagePatch(int damageNumber){
            if (!Config.VibrateOnTakingDamage.Value) return;

            Plugin.Mls.LogInfo($"Client was hurt, spiking vibration (+ {damageNumber}%)");
            Plugin.DeviceManager.increaseVibration(damageNumber / 100f);
        }

        [HarmonyPatch(typeof(PlayerControllerB), "KillPlayer")]
        [HarmonyPostfix]
        private static void OnKilledPatch(ref PlayerControllerB __instance){
            if (!Config.VibrateOnDeath.Value) return;
            
            if (__instance != GameNetworkManager.Instance.localPlayerController) return;

            Plugin.Mls.LogInfo($"Client died, spiking vibration (+ {Config.VibrateOnDeathStrength.Value * 100}%)");
            Plugin.DeviceManager.increaseVibration(Config.VibrateOnDeathStrength.Value);
        }

        [HarmonyPatch(typeof(PlayerControllerB), "Jump_performed")]
        [HarmonyPrefix]
        private static void OnJumpPatch(ref PlayerControllerB __instance, ref bool ___isJumping){
            if (!Config.VibrateOnJump.Value) return;

            if (__instance != GameNetworkManager.Instance.localPlayerController) return;
            if (!__instance.thisController.isGrounded || ___isJumping || __instance.inTerminalMenu) return;

            Plugin.Mls.LogInfo($"Client jumped, spiking vibration (+ {Config.VibrateOnJumpStrength.Value * 100}%)");
            Plugin.DeviceManager.increaseVibration(Config.VibrateOnJumpStrength.Value);
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void IsSprintingPatch(ref PlayerControllerB __instance){
            if (!Config.VibrateOnSprint.Value) return;

            if (__instance != GameNetworkManager.Instance.localPlayerController) return;

            Plugin.DeviceManager.isRunning = __instance.isSprinting;
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void IsUsingJetpackPatch(ref PlayerControllerB __instance){
            if (!Config.VibrateOnJetpack.Value) return;

            if (__instance != GameNetworkManager.Instance.localPlayerController) return;

            Plugin.DeviceManager.isUsingJetpack = __instance.jetpackControls;
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void IsSpectatingPatch(ref PlayerControllerB __instance){
            if (!Config.VibrateOnSpectate.Value) return;

            if (__instance != GameNetworkManager.Instance.localPlayerController) return;

            Plugin.DeviceManager.isSpectating = __instance.hasBegunSpectating;
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void BeingZappedByZapGunPatch(ref PlayerControllerB __instance){
            if (!Config.VibrateOnBeingZapped.Value) return;

            if (GameNetworkManager.Instance.localPlayerController != __instance) return;

            if (__instance.hinderedMultiplier < 3.5)
            {
                Plugin.DeviceManager.isBeingZapped = false;

                return;
            }

            Plugin.DeviceManager.isBeingZapped = true;
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void ZappingWithZapGunPatch(ref PlayerControllerB __instance){
            if (!Config.VibrateOnZapping.Value) return;

            if (GameNetworkManager.Instance.localPlayerController != __instance) return;

            Plugin.DeviceManager.isZapping = __instance.inShockingMinigame;
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void Vibrate(ref PlayerControllerB __instance){
            if (__instance != GameNetworkManager.Instance.localPlayerController) return;

            Plugin.DeviceManager.Vibrate();
        }
    }
}