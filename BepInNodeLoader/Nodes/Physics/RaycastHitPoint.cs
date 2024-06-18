using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Physics;

public class RaycastHitPoint : Node
{
    [IsArgOut]
    public Vector3 Position { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var hitInfo = (UnityEngine.RaycastHit)args[0];
        Position = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
    }
}
