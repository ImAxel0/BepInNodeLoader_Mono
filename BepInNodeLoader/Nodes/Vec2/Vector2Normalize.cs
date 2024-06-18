using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Vec2;

public class Vector2Normalize : Node
{
    public Vector2 Vector2 { get; set; }

    public override void Execute()
    {
        List<object> list = ArgumentsRetriever.GetArgumentsOf(this);
        var v2 = (Vector2)list[0];
        var uv2 = new UnityEngine.Vector2(v2.X, v2.Y);
        uv2.Normalize();
        Vector2 = new Vector2(uv2.x, uv2.y);
    }
}
