using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.Rigidbody;

public class RbAddTorque : Node
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public Vector3 Direction { get; set; }
    public UnityEngine.ForceMode EnumValue { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var rb = (UnityEngine.Rigidbody)args[0];
        var dir = (Vector3)args[1];
        rb.AddTorque(new UnityEngine.Vector3(dir.X, dir.Y, dir.Z), (UnityEngine.ForceMode)args[2]);
    }
}
