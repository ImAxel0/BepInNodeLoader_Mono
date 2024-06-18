using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Vec3;

public class Vector3Distance : Node
{
    public Vector3 A { get; set; }
    public Vector3 B { get; set; }

    [IsArgOut]
    public float Distance { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var a = (Vector3)args[0];
        var b = (Vector3)args[1];
        Distance = UnityEngine.Vector3.Distance(new UnityEngine.Vector3(a.X, a.Y, a.Z), new UnityEngine.Vector3(b.X, b.Y, b.Z));
    }
}
