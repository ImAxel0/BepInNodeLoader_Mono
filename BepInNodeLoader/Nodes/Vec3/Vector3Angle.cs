using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Vec3;

public class Vector3Angle : Node
{
    public Vector3 From { get; set; }
    public Vector3 To { get; set; }

    [IsArgOut]
    public float Angle { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var v3_1 = (Vector3)args[0];
        var v3_2 = (Vector3)args[1];
        Angle = UnityEngine.Vector3.Angle(new UnityEngine.Vector3(v3_1.X, v3_1.Y, v3_1.Z),
            new UnityEngine.Vector3(v3_2.X, v3_2.Y, v3_2.Z));
    }
}
