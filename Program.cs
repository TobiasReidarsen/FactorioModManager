using System;
using System.IO;
using System.Text.Json;
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
            factorioPath = roaming + @"\Factorio\mods\empty-mod.json";


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

        static ModList GetEnabledMods(ModList modList) 
        {
            try
            {
                var allEnabledMods =
                    (from mods in modList.mods
                     where mods.enabled == true
                     select mods).DefaultIfEmpty().ToList();
                
                return new ModList(allEnabledMods);

            } catch (JsonException ex) 
            {
                return new ModList(new List<Mod>());
            }
        }
    }
}
