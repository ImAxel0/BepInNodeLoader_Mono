using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.Transform;

public class SetEulerAngles : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }

    public Vector3 xyz { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var tr = (UnityEngine.Transform)args[0];
        var angles = (Vector3)args[1];
        tr.eulerAngles = new UnityEngine.Vector3(angles.X, angles.Y, angles.Z);
    }
}
