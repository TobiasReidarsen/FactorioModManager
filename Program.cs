using FactorioModManagerReal.Models;

namespace FactorioModManagerReal
{
    public class Program
    {
        static void Main(string[] args)
        {
	    string roaming = string.Empty;
	    var factorioPathWindows =roaming+ @"\Factorio\mods\mod-list.json";
		
	    var factorioPath = string.Empty;
	    	if (args.Length == 0){
			do
			{	Console.WriteLine("Please input a valid path:");
		    		factorioPath = ParseCmdArgs.GetJsonPath(Console.ReadLine() ?? string.Empty);
				Console.WriteLine(factorioPath);
			} while (factorioPath.Equals(string.Empty));	
		}

            if (args.Length != 0) 
            {
                factorioPath = ParseCmdArgs.GetJsonPath(args[0]);
		do 
		{
                    Console.WriteLine("Invalid Path!");
                    factorioPath = ParseCmdArgs.GetJsonPath(Console.ReadLine() ?? string.Empty);

                    Console.Clear();
		}
                while (factorioPath.Equals(string.Empty));

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
