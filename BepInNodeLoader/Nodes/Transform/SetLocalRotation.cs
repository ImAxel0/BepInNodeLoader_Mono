using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.Transform;

public class SetLocalRotation : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }

    public Vector3 Rotation { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var tr = (UnityEngine.Transform)args[0];
        var rot = (Vector3)args[1];
        tr.localRotation = UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(rot.X, rot.Y, rot.Z));
    }
}
