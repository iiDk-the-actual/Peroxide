using HarmonyLib;
using UnityEngine;

namespace Peroxide.Patches.UnityEngine.Debug
{
    public static class LogWarning
    {
        [HarmonyPatch(typeof(global::UnityEngine.Debug), "LogWarning", new[] { typeof(object) })]
        [HarmonyPriority(Priority.First)]
        public static class LogObject
        {
            private static bool Prefix(object message)
            {
                System.Console.WriteLine(message);
                return false;
            }
        }

        [HarmonyPatch(typeof(global::UnityEngine.Debug), "LogWarning", new[] { typeof(object), typeof(Object) })]
        [HarmonyPriority(Priority.First)]
        public static class LogContext
        {
            private static bool Prefix(object message, Object context)
            {
                System.Console.WriteLine($"{message}\n{typeof(global::UnityEngine.Debug).FullName}:Log (object, {context.GetType().FullName})");
                return false;
            }
        }
    }

    public static class LogWarningFormat
    {
        [HarmonyPatch(typeof(global::UnityEngine.Debug), "LogWarningFormat", new[] { typeof(string), typeof(object[]) })]
        [HarmonyPriority(Priority.First)]
        public static class LogObject
        {
            private static bool Prefix(string format, params object[] args)
            {
                System.Console.WriteLine(string.Format(format, args));
                return false;
            }
        }

        [HarmonyPatch(typeof(global::UnityEngine.Debug), "LogWarningFormat", new[] { typeof(Object), typeof(string), typeof(object[]) })]
        [HarmonyPriority(Priority.First)]
        public static class LogContext
        {
            private static bool Prefix(Object context, string format, params object[] args)
            {
                System.Console.WriteLine($"{string.Format(format, args)}\n{typeof(global::UnityEngine.Debug).FullName}:Log (object, {context.GetType().FullName})");
                return false;
            }
        }
    }
}
