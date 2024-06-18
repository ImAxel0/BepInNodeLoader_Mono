using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.Rigidbody;

public class RbSetVelocity : Node
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public Vector3 Velocity { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var rb = (UnityEngine.Rigidbody)args[0];
        var v3 = (Vector3)args[1];
        rb.velocity = new UnityEngine.Vector3(v3.X, v3.Y, v3.Z);
    }
}
