namespace FactorioModManagerReal;

public static class ParseCmdArgs
{
    public static string GetJsonPath(string path)
    {

        if (!File.Exists(path) || !path.EndsWith(".json")) { return string.Empty; }

        return path;
    }
}
