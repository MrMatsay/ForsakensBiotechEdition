using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;

namespace ForsakenBiotech
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            var harmony = new Harmony("ForsakenBiotech");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    //---------- PLANT UTILITY PATCHES ----------//
    [HarmonyPatch(typeof(PlantUtility), "GrowthSeasonNow", 0)]
    public static class Patch_PlantUtility
    {
        [HarmonyPostfix]
        public static void Postfix(IntVec3 c, Map map, ref bool __result)
        {
            Plant plant = c.GetPlant(map);

            string str = plant?.def?.defName;
            if (str == "FO_PlantUltraviolett")
            {
                __result = true;
            }
            else if ((c.GetZone(map) is Zone_Growing zone_Growing) && zone_Growing.GetPlantDefToGrow().defName == "FO_PlantUltraviolett")
            {
                __result = true;
            }
        }
    }
}
