using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Vec2;

public class Vector2Lerp : Node
{
    public Vector2 A { get; set; }
    public Vector2 B { get; set; }
    public float T { get; set; }

    [IsArgOut]
    public Vector2 Result { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var v2_1 = (Vector2)args[0];
        var v2_2 = (Vector2)args[1];
        var result =  UnityEngine.Vector2.Lerp(new UnityEngine.Vector2(v2_1.X, v2_1.Y),
            new UnityEngine.Vector2(v2_2.X, v2_2.Y), (float)args[2]);
        Result = new Vector2(result.x, result.y);
    }
}
