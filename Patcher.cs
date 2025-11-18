using HarmonyLib;
using KSA;

namespace StellarAnalytics
{
    [HarmonyPatch]
    internal static class Patcher
    {
        private static Harmony? _harmony = new Harmony("StellarAnalytics");

        public static void Patch()
        {
            Console.WriteLine("Patching StellarAnalytics...");
            _harmony?.PatchAll(typeof(Patcher).Assembly);
        }

        public static void Unload()
        {
            _harmony?.UnpatchAll(_harmony.Id);
            _harmony = null;
        }

        [HarmonyPatch(typeof(ModLibrary), nameof(ModLibrary.LoadAll))]
        [HarmonyPostfix]
        public static void AfterLoad()
        {
            
        }
    }
}