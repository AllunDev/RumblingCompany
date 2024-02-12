using GameNetcodeStuff;
using HarmonyLib;

namespace RumblingCompany.Patches
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class EnemyAIPatch
    {
        [HarmonyPatch(typeof(EnemyAI), "HitEnemy")]
        [HarmonyPrefix]
        private static void HitEnemyPatch(PlayerControllerB playerWhoHit, ref int ___enemyHP){
            if (playerWhoHit != GameNetworkManager.Instance.localPlayerController || ___enemyHP == 0) return;

            if (___enemyHP == 1 && Config.KillingEnabled.Value)
            {
                Plugin.Mls.LogInfo($"Client killed enemy, spiking vibration (+ {Config.KillingStrength.Value * 100}%)");

                Plugin.DeviceManager.increaseVibration(Config.KillingStrength.Value);

                return;
            }

            if (!Config.DealingDamageEnabled.Value) return;

            Plugin.Mls.LogInfo($"Client hit enemy, spiking vibration (+ {Config.DealingDamageStrength.Value * 100}%)");
            Plugin.DeviceManager.increaseVibration(Config.DealingDamageStrength.Value);
        }
    }
}