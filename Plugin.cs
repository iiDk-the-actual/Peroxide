using System;
using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace Peroxide
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance { get; private set; }

        void Awake()
        {
            Logger.Log("Peroxide - Created by goldentrophy");
            instance = this;
#if RELEASE
            Debug.unityLogger.logEnabled = false;
#endif
            HarmonyPatches.ApplyHarmonyPatches();

            GorillaTagger.OnPlayerSpawned(PlayerSpawned);
        }

        void PlayerSpawned()
        {
            Application.targetFrameRate = 144;
            QualitySettings.SetQualityLevel(1);
            QualitySettings.antiAliasing = 0;
            QualitySettings.shadows = ShadowQuality.Disable;
            QualitySettings.particleRaycastBudget = 0;
            QualitySettings.pixelLightCount = 0;
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
            QualitySettings.realtimeReflectionProbes = false;
            QualitySettings.globalTextureMipmapLimit = 0;
            QualitySettings.lodBias = 0f;
            QualitySettings.pixelLightCount = 0;
            QualitySettings.realtimeReflectionProbes = false;
            QualitySettings.enableLODCrossFade = false;
            QualitySettings.maximumLODLevel = 0;

            foreach (Camera camera in Camera.allCameras)
            {
                camera.allowMSAA = false;
                camera.focusDistance = 0f;
                camera.farClipPlane = 50f;
                camera.focusDistance = 1f;
                camera.allowHDR = false;
            }

            Camera.main.farClipPlane = 50f;
            Camera.main.anamorphism = 0f;
        }
    }
}
