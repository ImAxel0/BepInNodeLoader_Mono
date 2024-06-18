using System.Numerics;
using BepInNodeLoader.CustomAttributes;
using BepInNodeLoader.Core;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.Math;

public class SubtractVec3 : Node
{
    public Vector3 First { get; set; }
    public Vector3 Second { get; set; }

    [IsArgOut]
    public Vector3 Result { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        Result = (Vector3)args[0] - (Vector3)args[1];
    }
}
