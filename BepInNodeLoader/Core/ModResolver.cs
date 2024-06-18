using BepInNodeLoader.CustomAttributes;
using BepInNodeLoader.Nodes.Flow;
using BepInNodeLoader.Utilities;
using System.Collections.Generic;
using System.Linq;
using BepInNodeLoader.Nodes.Events;

namespace BepInNodeLoader.Core;

public class ModResolver
{
    private static bool ShouldStorePair(Node node)
    {
        return !node.GetType().GetCustomAttributes(false).Any(at => at.GetType() == typeof(IsGetVariable));
    }

    private static List<If> GetAllIfStatements(If topLevelIfStatement)
    {
        List<If> allIfStatements = new()
        {
            topLevelIfStatement
        };

        foreach (var node in topLevelIfStatement.TrueBranchNodes)
        {
            if (node.GetType() == typeof(If))
                allIfStatements.AddRange(GetAllIfStatements((If)node));
        }

        foreach (var node in topLevelIfStatement.FalseBranchNodes)
        {
            if (node.GetType() == typeof(If))
                allIfStatements.AddRange(GetAllIfStatements((If)node));
        }
        return allIfStatements;
    }

    public static List<string> ResolveConnections(Node connection)
    {
        List<string> stored = new();

        if (connection.GetType() == typeof(If))
        {
            if (!ModsData.IdNodePair.ContainsKey(connection.Id))
            {
                ModsData.IdNodePair.Add(connection.Id, connection);
                stored.Add(connection.Id);
            }

            var allIfNodes = GetAllIfStatements((If)connection);

            foreach (var ifNode in allIfNodes)
            {
                ifNode.TrueBranchNodes.ForEach(node => {

                    if (!ModsData.IdNodePair.ContainsKey(node.Id) && ShouldStorePair(node))
                    {
                        ModsData.IdNodePair.Add(node.Id, node);
                        stored.Add(node.Id);
                    }
                });

                ifNode.FalseBranchNodes.ForEach(node => {

                    if (!ModsData.IdNodePair.ContainsKey(node.Id) && ShouldStorePair(node))
                    {
                        ModsData.IdNodePair.Add(node.Id, node);
                        stored.Add(node.Id);
                    }
                });
            }
        }
        else if (!ModsData.IdNodePair.ContainsKey(connection.Id) && ShouldStorePair(connection))
        {
            ModsData.IdNodePair.Add(connection.Id, connection);
            stored.Add(connection.Id);
        }

        return stored;
    }

    public static List<string>[] PopulateCustomEvents(ModData modData)
    {
        List<string> stored = new();
        List<string> storedCEvents = new();

        modData.CustomEvents.ForEach(cEvent => {

            // adding the custom event to the nodes dictionary
            if (!ModsData.IdNodePair.ContainsKey(cEvent.Id))
            {
                ModsData.IdNodePair.Add(cEvent.Id, cEvent);
                stored.Add(cEvent.Id);
            }

            // adding the custom event to the events dictionary
            var customEvent = (CustomEvent)cEvent;
            if (!ModsData.CustomEvents.ContainsKey(customEvent.EventId))
            {
                ModsData.CustomEvents.Add(customEvent.EventId, customEvent);
                storedCEvents.Add(customEvent.EventId);
            }
            else
                BLogger.BLog.LogError($"{modData.ModName} mod contains a {nameof(CustomEvent)} which has the same EventId as another mod.");

            // handling custom event
            foreach (var node in customEvent.EventNodes)
            {
                if (node.GetType() == typeof(If))
                {
                    if (!ModsData.IdNodePair.ContainsKey(node.Id))
                    {
                        ModsData.IdNodePair.Add(node.Id, node);
                        stored.Add(node.Id);
                    }

                    var allIfNodes = GetAllIfStatements((If)node);

                    foreach (var ifNode in allIfNodes)
                    {
                        ifNode.TrueBranchNodes.ForEach(node => {

                            if (!ModsData.IdNodePair.ContainsKey(node.Id) && ShouldStorePair(node))
                            {
                                ModsData.IdNodePair.Add(node.Id, node);
                                stored.Add(node.Id);
                            }
                        });

                        ifNode.FalseBranchNodes.ForEach(node => {

                            if (!ModsData.IdNodePair.ContainsKey(node.Id) && ShouldStorePair(node))
                            {
                                ModsData.IdNodePair.Add(node.Id, node);
                                stored.Add(node.Id);
                            }
                        });
                    }
                }
                else if (!ModsData.IdNodePair.ContainsKey(node.Id) && ShouldStorePair(node))
                {
                    ModsData.IdNodePair.Add(node.Id, node);
                    stored.Add(node.Id);
                }
            }
        });
        return [ stored, storedCEvents ];
    }
}
