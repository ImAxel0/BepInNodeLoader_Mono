using BepInNodeLoader.Core;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.Events;

public class CallCustomEvent : Node
{
    public string EventId { get; set; }
    public string EventName { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        ModsData.GetCustomEvent((string)args[0]).Execute();
    }
}
