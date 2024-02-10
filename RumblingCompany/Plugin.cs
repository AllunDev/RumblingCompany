using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace RumblingCompany
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static DeviceManager DeviceManager { get; private set; }
        internal static ManualLogSource Mls { get; private set; }

        private void Awake()
        {
            Mls = Logger;

            // Plugin startup logic
            DeviceManager = new DeviceManager("Rumbling Company");
            DeviceManager.ConnectDevices();

            var harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll(typeof(Patches.PlayerControllerBPatch));
            harmony.PatchAll(typeof(Patches.HUDManagerPatch));
            harmony.PatchAll(typeof(Patches.ItemChargerPatch));
            harmony.PatchAll(typeof(Patches.WalkieTalkiePatch));
            harmony.PatchAll(typeof(Patches.EnemyAIPatch));
            harmony.PatchAll(typeof(Patches.RoundManagerPatch));


            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
