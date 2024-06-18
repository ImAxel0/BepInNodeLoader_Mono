using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.GameObject;

public class GoGetComponent : Node
{
    [XmlIgnore]
    public UnityEngine.GameObject GameObject { get; set; }
    public string ComponentName { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public UnityEngine.Component Component { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var go = (UnityEngine.GameObject)args[0];
        Component = go.GetComponent((string)args[1]);
    }
}
