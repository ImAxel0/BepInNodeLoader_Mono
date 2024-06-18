using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Numerics;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.Math;

public class DivideVec3 : Node
{
    public Vector3 First { get; set; }
    public Vector3 Second { get; set; }

    [IsArgOut]
    public Vector3 Result { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        Result = (Vector3)args[0] / (Vector3)args[1];
    }
}
