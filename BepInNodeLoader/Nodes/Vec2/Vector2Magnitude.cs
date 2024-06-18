using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Vec2;

public class Vector2Magnitude : Node
{
    public Vector2 Vector2 { get; set; }

    [IsArgOut]
    public float Magnitude { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var vec2 = (Vector2)args[0];
        Magnitude = new UnityEngine.Vector2(vec2.X, vec2.Y).magnitude;
    }
}
