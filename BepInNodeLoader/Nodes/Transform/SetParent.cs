using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.Transform;

public class SetParent : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }

    [XmlIgnore]
    public UnityEngine.Transform NewParent { get; set; }

    public bool WorldPositionStays { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var tr = (UnityEngine.Transform)args[0];
        var newParent = (UnityEngine.Transform)args[1];
        tr.SetParent(newParent, (bool)args[2]);
    }
}
