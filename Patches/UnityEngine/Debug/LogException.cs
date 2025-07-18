using HarmonyLib;
using System;

namespace Peroxide.Patches.UnityEngine.Debug
{
    public static class LogException
    {
        [HarmonyPatch(typeof(global::UnityEngine.Debug), "LogException", new[] { typeof(Exception) })]
        [HarmonyPriority(Priority.First)]
        public static class LogObject
        {
            private static bool Prefix(Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }

        [HarmonyPatch(typeof(global::UnityEngine.Debug), "LogException", new[] { typeof(Exception), typeof(global::UnityEngine.Object) })]
        [HarmonyPriority(Priority.First)]
        public static class LogContext
        {
            private static bool Prefix(Exception exception, global::UnityEngine.Object context)
            {
                Console.WriteLine($"{exception}\n{typeof(global::UnityEngine.Debug).FullName}:Log (object, {context.GetType().FullName})");
                return false;
            }
        }
    }
}
