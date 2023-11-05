using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioModManagerReal;

static public class ParseCmdArgs
{
    static public string GetJsonPath(string path)
    {
        while (true)
        {

            if (!File.Exists(path))
            {
                Console.WriteLine("Invalid Path, enter another path");
                path = Console.ReadLine();

                if (path == null) { Console.WriteLine("Enter valid path omg"); continue; }

                if (!path.EndsWith("mod-list.json"))
                {
                    Console.WriteLine("Invalid file. Enter a new path");

                    continue;
                }

            }

            return path;

        }
    }
}
