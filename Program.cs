using FactorioModManagerReal.Models;

namespace FactorioModManagerReal
{
    public class Program
    {
        static void Main(string[] args)
        {
            var roaming = System.Environment.GetEnvironmentVariable("APPDATA");
            var factorioPath = roaming + @"\Factorio\mods\mod-list.json";

            if (args.Length != 0) 
            {
                factorioPath = ParseCmdArgs.GetJsonPath(args[0]);

                while (factorioPath.Equals(string.Empty)) {
                    Console.WriteLine("Invalid Path!");
                    factorioPath = ParseCmdArgs.GetJsonPath(Console.ReadLine() ?? string.Empty);

                    Console.Clear();
                }
            }


            ModList modList = ModViewer.GetModsFromFile(factorioPath);

            ModList inactiveMods = new ModList(
                (from mod in modList.mods
                where mod.enabled != true
                select mod).DefaultIfEmpty().ToList());

            ModList enabledMods = ModViewer.GetEnabledMods(modList);

            ModList[] allMods = { modList, inactiveMods, enabledMods };

            Array.ForEach(allMods, mod => {
                Console.Write($"Downloaded mods: {enabledMods.mods.Count} | Enabled Mods {enabledMods.mods.Count}\n" +"Mod name | Enabled\n------\n"); 
                mod.mods.ForEach(mod => Console.WriteLine($"{mod.name,5} | {mod.enabled,5}"));
                Console.ReadKey(); Console.Clear();
            });
        }
    }
}
