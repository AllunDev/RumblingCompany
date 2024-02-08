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

            if (___enemyHP == 1)
            {
                Plugin.Mls.LogInfo($"Client killed enemy, vibrating");
                Plugin.DeviceManager.increaseVibration(0.70f);

                return;
            }

            Plugin.Mls.LogInfo($"Client hit enemy, vibrating");
            Plugin.DeviceManager.increaseVibration(0.3f);
        }
    }
}