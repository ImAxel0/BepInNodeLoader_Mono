using BepInNodeLoader.Core.NodeActions;
using BepInNodeLoader.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BepInNodeLoader.Nodes.Events;

namespace BepInNodeLoader.Core;

public class ModsData
{
    /// <summary>
    /// all mods data
    /// </summary>
    public static List<ModData> AllModsData = new();

    /// all mods custom events id's and event instances
    /// </summary>
    public static Dictionary<string, CustomEvent> CustomEvents { get; set; } = new();

    /// <summary>
    /// all mods nodes id's and node instances
    /// </summary>
    public static Dictionary<string, Node> IdNodePair { get; set; } = new();

    public static Node GetNodeById(string id)
    {
        if (IdNodePair.TryGetValue(id, out Node node))
        {
            return node;
        }
        return null;
    }

    public static CustomEvent GetCustomEvent(string eventId)
    {
        if (CustomEvents.TryGetValue(eventId, out CustomEvent customEvent))
        {
            return customEvent;
        }
        return null;
    }

    public static void ReplaceIdNodePair<T1, T2>(Dictionary<T1, T2> d, T1 key, T1 newKey, T2 newValue)
    {
        if (d.ContainsKey(key))
        {
            d.Remove(key);
            d.Add(newKey, newValue);
        }
    }

    public static void SetupMods()
    {
        var modsFolder = Path.Combine(BepInEx.Paths.PluginPath, "BepInNodeMods");
        if (!Directory.Exists(modsFolder))
            Directory.CreateDirectory(modsFolder);

        foreach (var mod in Directory.GetFiles(modsFolder).Where(file => Path.GetExtension(file) == ".nodemod"))
        {
            ModsData.AllModsData.Add(Serialization.GetModData(mod));
        }

        ModsData.AllModsData.ForEach(modData =>
        {
            BLogger.BLog.LogInfo($"Mod: {modData.ModName}.nodemod");
            BLogger.BLog.LogInfo($"Author: {modData.ModAuthor}");
            BLogger.BLog.LogInfo($"Version: v{modData.ModVersion}");
        });
    }

    public static void LoadMods()
    {
        ModsData.AllModsData.ForEach(modData =>
        {
            ModResolver.PopulateCustomEvents(modData);
            modData.Update.ForEach(node =>
            {
                ModResolver.ResolveConnections(node);
                OnUpdate.Subscribe(node.Execute);
            });

            modData.FixedUpdate.ForEach(node =>
            {
                ModResolver.ResolveConnections(node);
                OnFixedUpdate.Subscribe(node.Execute);
            });
        });
    }
}
