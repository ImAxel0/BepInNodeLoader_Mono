using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Math;

public class MultiplyVec3ByNumber : Node
{
    public Vector3 First { get; set; }
    public float Second { get; set; }

    [IsArgOut]
    public Vector3 Result { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        Result = (Vector3)args[0] * (float)args[1];
    }
}
