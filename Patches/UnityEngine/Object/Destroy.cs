using HarmonyLib;
using System;

namespace Peroxide.Patches.UnityEngine.GameObject
{
    [HarmonyPatch(typeof(global::UnityEngine.Object), "Destroy", new Type[] { typeof(global::UnityEngine.Object), typeof(float) })]
    [HarmonyPriority(Priority.First)]
    public static class Destroy
    {
        private static bool Prefix(global::UnityEngine.Object obj, float t = 0.0f)
        {
            global::UnityEngine.Object.DestroyImmediate(obj, false);
            return false;
        }
    }
}
