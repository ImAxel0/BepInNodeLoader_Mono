using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Vec2;

public class Vector2Angle : Node
{
    public Vector2 From { get; set; }
    public Vector2 To { get; set; }

    [IsArgOut]
    public float Angle { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var v2_1 = (Vector2)args[0];
        var v2_2 = (Vector2)args[1];
        Angle = UnityEngine.Vector2.Angle(new UnityEngine.Vector2(v2_1.X, v2_1.Y),
            new UnityEngine.Vector2(v2_2.X, v2_2.Y));
    }
}
