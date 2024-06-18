using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Vec3;

public class Vector3Magnitude : Node
{
    public Vector3 Vector3 { get; set; }

    [IsArgOut]
    public float Magnitude { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var vec3 = (Vector3)args[0];
        Magnitude = new UnityEngine.Vector3(vec3.X, vec3.Y, vec3.Z).magnitude;
    }
}
