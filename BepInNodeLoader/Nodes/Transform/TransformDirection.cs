using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.Transform;

public class TransformDirection : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }
    public Vector3 Direction { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var tr = (UnityEngine.Transform)args[0];
        var v3 = (Vector3)args[1];
        tr.TransformDirection(new UnityEngine.Vector3(v3.X, v3.Y, v3.Z));
    }
}
