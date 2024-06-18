using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace BepInNodeLoader.Nodes.Methods;

public class CallMethod : Node
{
    [XmlIgnore]
    public Component Component { get; set; }

    public string MethodName { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var com = (Component)args[0];
        com.GetType().GetMethod((string)args[1], System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
            | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).Invoke(com, null);
    }
}
