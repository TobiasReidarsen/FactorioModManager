using System.Text.Json;
using FactorioModManagerReal.Models;

namespace FactorioModManagerReal
{

    public class Program
    {

        static void Main(string[] args)
        {
            var roaming = System.Environment.GetEnvironmentVariable("APPDATA");
            var factorioPath = roaming + "\\Factorio\\mods\\mod-list.json";


            if (args.Length != 0) 
            {
                factorioPath = ParseCmdArgs.GetJsonPath(args[0]);
            }
            

            var mods = GetModsFromFile(factorioPath);

            var enabledMods = GetEnabledMods(mods);

            Console.Write($"Downloaded mods: {mods.mods.Count} | Enabled Mods {mods.mods.Count}\n" +
                $"Mod Name | Enabled\n------\n");

            foreach (var item in mods.mods)
            {
                Console.WriteLine($"{item.name, 5} | {item.enabled, 5}");
            }



        }
        static ModList GetModsFromFile(string modPath)
        {

            using (StreamReader sr = File.OpenText(modPath))
            {
                var modList = JsonSerializer.Deserialize<ModList>
                    (sr.ReadToEnd());
                return modList;

            }
        }

        static IEnumerable<Mod> GetEnabledMods(ModList modList) 
        {
            var allEnabledMods =
                from mods in modList.mods
                where mods.enabled == true
                select mods;
                
            return allEnabledMods.DefaultIfEmpty();
        }
    }
}
