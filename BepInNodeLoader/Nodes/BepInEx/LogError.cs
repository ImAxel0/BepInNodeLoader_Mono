using BepInNodeLoader.Core;
using BepInNodeLoader.Utilities;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.BepInEx;

public class LogError : Node
{
    public string Message { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        BLogger.BLog.LogError((string)args[0]);
    }
}
