using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioModManagerReal;

public static class ParseCmdArgs
{
    public static string GetJsonPath(string path)
    {

        if (!File.Exists(path) || !path.EndsWith(".json")) { return string.Empty; }

        return path;

        while (true)
        {
            string newPath = Console.ReadLine() ?? string.Empty;

            if (!File.Exists(newPath) || !newPath.EndsWith(".json"))
            {
                Console.WriteLine("Invalid Path, enter another path");
                continue;
            }

            return newPath;

        }
    }
}
