using System;
using BepInEx;
using BepInEx.Logging;

namespace Peroxide
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance { get; private set; }
        public ManualLogSource Log => Logger;

        void Awake()
        {
            Logger.Log("Peroxide - Created by goldentrophy");
            instance = this;

            HarmonyPatches.ApplyHarmonyPatches();
        }
    }
}
