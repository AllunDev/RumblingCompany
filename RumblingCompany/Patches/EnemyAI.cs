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

            if (___enemyHP == 1 && Config.VibrateOnKill.Value)
            {
                Plugin.Mls.LogInfo($"Client killed enemy, spiking vibration (+ {Config.VibrateOnKillStrength.Value * 100}%)");

                Plugin.DeviceManager.increaseVibration(Config.VibrateOnKillStrength.Value);

                return;
            }

            if (!Config.VibrateOnDealingDamage.Value) return;

            Plugin.Mls.LogInfo($"Client hit enemy, spiking vibration (+ {Config.VibrateOnDealingDamageStrength.Value * 100}%)");
            Plugin.DeviceManager.increaseVibration(Config.VibrateOnDealingDamageStrength.Value);
        }
    }
}