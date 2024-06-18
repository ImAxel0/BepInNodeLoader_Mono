using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Vec3;

public class Vector3Lerp : Node
{
    public Vector3 A { get; set; }
    public Vector3 B { get; set; }
    public float T { get; set; }

    [IsArgOut]
    public Vector3 Result { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var v3_1 = (Vector3)args[0];
        var v3_2 = (Vector3)args[1];
        var result =  UnityEngine.Vector3.Lerp(new UnityEngine.Vector3(v3_1.X, v3_1.Y, v3_1.Z),
            new UnityEngine.Vector3(v3_2.X, v3_2.Y, v3_2.Z), (float)args[2]);
        Result = new Vector3(result.x, result.y, result.z);
    }
}
