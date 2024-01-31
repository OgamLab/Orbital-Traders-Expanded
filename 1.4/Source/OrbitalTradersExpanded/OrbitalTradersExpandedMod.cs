using HarmonyLib;
using Verse;


namespace OrbitalTradersExpanded
{
    public class OrbitalTradersExpandedMod : Mod
    {
        public static Harmony harmony;
        public OrbitalTradersExpandedMod(ModContentPack content) : base(content)
        {
            harmony = new Harmony("OrbitalTradersExpanded.Mod");
            harmony.PatchAll();
        }
    }
}