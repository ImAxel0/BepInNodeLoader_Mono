using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Vec2;

public class Vector2Distance : Node
{
    public Vector2 A { get; set; }
    public Vector2 B { get; set; }

    [IsArgOut]
    public float Distance { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var a = (Vector2)args[0];
        var b = (Vector2)args[1];
        Distance = UnityEngine.Vector2.Distance(new UnityEngine.Vector2(a.X, a.Y), new UnityEngine.Vector2(b.X, b.Y));
    }
}
