using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.GameObject;

public class SetActive : Node
{
    [XmlIgnore]
    public UnityEngine.GameObject GameObject { get; set; }
    public bool Value { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var go = (UnityEngine.GameObject)args[0];
        go.SetActive((bool)args[1]);
    }
}
