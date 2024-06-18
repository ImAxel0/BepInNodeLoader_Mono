using System.Numerics;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using BepInNodeLoader.Core;

namespace BepInNodeLoader.Nodes.TypeUtility;

public class BreakVector3 : Node
{
    [IsArgOut]
    public float X { get; set; }
    [IsArgOut]
    public float Y { get; set; }
    [IsArgOut]
    public float Z { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var vec3 = (Vector3)args[0];
        X = vec3.X; Y = vec3.Y; Z = vec3.Z;
    }
}
