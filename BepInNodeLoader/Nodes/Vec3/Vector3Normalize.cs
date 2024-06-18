using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Vec3;

public class Vector3Normalize : Node
{
    public Vector3 Vector3 { get; set; }

    public override void Execute()
    {
        List<object> list = ArgumentsRetriever.GetArgumentsOf(this);
        var v3 = (Vector3)list[0];
        var uv3 = new UnityEngine.Vector3(v3.X, v3.Y, v3.Z);
        uv3.Normalize();
        Vector3 = new Vector3(uv3.x, uv3.y, uv3.z);
    }
}
