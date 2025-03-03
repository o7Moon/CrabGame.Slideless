using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;

namespace slideless
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        public override void Load()
        {
            Harmony.CreateAndPatchAll(typeof(Plugin));

            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
        [HarmonyPatch(typeof(OnlinePlayer), nameof(OnlinePlayer.SetAnimation))]
        [HarmonyPostfix]
        public static void onCrouch(OnlinePlayer __instance, MonoBehaviourPublicObVeSiVeRiSiAnVeanTrUnique.EnumNPublicSealedvaCrMe3vUnique __0, bool __1, float __2){
            if (__1 && __0 == MonoBehaviourPublicObVeSiVeRiSiAnVeanTrUnique.EnumNPublicSealedvaCrMe3vUnique.Crouch) {
                UnityEngine.Debug.Log("AAAAAA");
                var id = __instance.field_Private_MonoBehaviourPublicCSstReshTrheObplBojuUnique_0.steamProfile.m_SteamID;
                GameServer.PlayerDied(id,id,UnityEngine.Vector3.down);
            }
        }
    }
}