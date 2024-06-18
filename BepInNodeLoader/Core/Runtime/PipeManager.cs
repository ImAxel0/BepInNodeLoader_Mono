using BepInNodeLoader.Core.NodeActions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;

namespace BepInNodeLoader.Core.Runtime;

public class PipeManager
{
    private static List<string> _lastIds = new();
    private static List<string> _lastCustomEventsIds = new();

    private static List<Action> _lastUpdate = new();
    private static List<Action> _lastFixedUpdate = new();

    static readonly string _pipeName = "BepInNodePipe";

    public static void WaitForConnection()
    {
        try
        {
            NamedPipeServerStream pipeServer = new NamedPipeServerStream(_pipeName,
               PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

            pipeServer.BeginWaitForConnection(new AsyncCallback(WaitForConnectionCallBack), pipeServer);
        }
        catch (Exception oEX)
        {
            Utilities.BLogger.BLog.LogError(oEX.Message);
        }
    }

    private static void WaitForConnectionCallBack(IAsyncResult iar)
    {
        try
        {
            NamedPipeServerStream pipeServer = (NamedPipeServerStream)iar.AsyncState;
            pipeServer.EndWaitForConnection(iar);

            using (StreamReader reader = new StreamReader(pipeServer))
            {
                try
                {
                    // Read the length of the incoming message
                    int length = int.Parse(reader.ReadLine());

                    // Read the XML string with the specified length
                    char[] buffer = new char[length];
                    reader.Read(buffer, 0, length);
                    string rmod = new string(buffer, 0, length);

                    if (rmod == "stop")
                    {
                        CleanPreviousMod();
                        CreateNewServer(pipeServer);
                        return;
                    }

                    var modData = Serialization.GetModDataFromContent(rmod);

                    CleanPreviousMod();

                    // saving nodes id's for later cleanup
                    modData.Update.ForEach(connection => {
                        var storedId = ModResolver.ResolveConnections(connection);
                        _lastIds.AddRange(storedId);
                    });

                    modData.FixedUpdate.ForEach(connection => {
                        var storedId = ModResolver.ResolveConnections(connection);
                        _lastIds.AddRange(storedId);
                    });

                    var eventNodesAndCustomEvents_Ids = ModResolver.PopulateCustomEvents(modData);
                    _lastIds.AddRange(eventNodesAndCustomEvents_Ids[0]); // nodes of custom events
                    _lastCustomEventsIds.AddRange(eventNodesAndCustomEvents_Ids[1]); // custom events nodes

                    // subscriptions
                    modData.Update.ForEach(connection => {
                        _lastUpdate.Add(connection.Execute);
                        OnUpdate.Subscribe(connection.Execute);
                    });

                    modData.FixedUpdate.ForEach(connection => {
                        _lastFixedUpdate.Add(connection.Execute);
                        OnFixedUpdate.Subscribe(connection.Execute);
                    });
                }
                catch (Exception e)
                {
                    Utilities.BLogger.BLog.LogError("Error processing mod: " + e.Message);
                }
            }

            CreateNewServer(pipeServer);
        }
        catch
        {
            return;
        }
    }

    private static void CreateNewServer(NamedPipeServerStream pipeServer)
    {
        pipeServer.Close();
        pipeServer = null;
        pipeServer = new NamedPipeServerStream(_pipeName, PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
        pipeServer.BeginWaitForConnection(new AsyncCallback(WaitForConnectionCallBack), pipeServer);
    }

    private static void CleanPreviousMod()
    {
        // global cleanup of used nodes
        foreach (var id in _lastIds.ToList())
        {
            ModsData.IdNodePair.Remove(id);
            _lastIds.Remove(id);
        }

        foreach (var id in _lastCustomEventsIds.ToList())
        {
            ModsData.CustomEvents.Remove(id);
            _lastCustomEventsIds.Remove(id);
        }

        // unsubscriptions
        foreach (var action in _lastUpdate.ToList())
        {
            OnUpdate.Unsubscribe(action);
            _lastUpdate.Remove(action);
        }

        foreach (var action in _lastFixedUpdate.ToList())
        {
            OnFixedUpdate.Unsubscribe(action);
            _lastUpdate.Remove(action);
        }
    }
}
