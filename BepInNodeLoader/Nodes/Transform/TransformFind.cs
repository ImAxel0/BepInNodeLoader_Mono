using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.Transform;

public class TransformFind : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }
    public string PathName { get; set; }

    [XmlIgnore]
    public UnityEngine.Transform FoundTr { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var tr = (UnityEngine.Transform)args[0];
        FoundTr = tr.Find((string)args[1]);
    }
}
