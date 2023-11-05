using System.Text.Json;
using System.Text.Json.Serialization;

namespace FactorioModManagerReal
{
    internal record struct Mod(string name, bool enabled);
    internal record struct ModList(List<Mod> mods);


    internal class Program
    {

        static void Main(string[] args)
        {
            var roaming = System.Environment.GetEnvironmentVariable("APPDATA");
            var factorioPath = "\\Factorio\\mods\\mod-list.json";

            while (true)
            {

                if (!File.Exists(roaming + factorioPath))
                {
                    Console.WriteLine("Invalid Path, enter another path");
                    factorioPath = Console.ReadLine();

                    if (factorioPath == null) { Console.WriteLine("Enter valid path omg"); continue; }

                    if (!factorioPath.EndsWith("mod-list.json"))
                    {
                        Console.WriteLine("Invalid file. Enter a new path");

                        continue;
                    }

                }

                break;

            }

            var mods = GetModsFromFile(roaming + factorioPath);
            Console.WriteLine(mods.ToString());

            var enabledMods = GetEnabledMods(mods);

            Console.Write($"Downloaded mods: {mods.mods.Count} | Enabled Mods {mods.mods.Count}\n" +
                $"Mod Name | Enabled\n------\n");

            foreach (var item in mods.mods)
            {
                Console.WriteLine($"{item.name, 5} | {item.enabled, 5}");
            }



        }
//static IEnumerable<Mods> GetMods()
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
                
            return allEnabledMods;
        }
    }
}
