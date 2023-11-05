using FactorioModManagerReal.Models;
using System.Text.Json;

namespace FactorioModManagerReal
{
    public static class ModViewer
    {
        public static ModList GetModsFromFile(string modPath)
        {
            using (StreamReader sr = File.OpenText(modPath))
            { // System.Text.Json.JsonException

                try
                {
                    var modList = JsonSerializer.Deserialize<ModList>
                    (sr.ReadToEnd());
                    return modList;

                }
                catch (JsonException ex)
                {
                    return new ModList(new List<Mod>()); ;
                }
            }
        }

        public static ModList GetEnabledMods(ModList modList)
        {
            try
            {
                var allEnabledMods =
                    (from mods in modList.mods
                     where mods.enabled == true
                     select mods).DefaultIfEmpty().ToList();

                return new ModList(allEnabledMods);

            }
            catch (JsonException ex)
            {
                return new ModList(new List<Mod>());
            }
        }
    }
}
