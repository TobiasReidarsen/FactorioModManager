namespace FactorioModManagerReal.Models;

public readonly record struct ModPack(List<Mod> Mods, List<ModPack>? ModPacks, string Name, bool Enabled);