using System.Numerics;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using BepInNodeLoader.Core;

namespace BepInNodeLoader.Nodes.TypeUtility;

public class MakeVector3 : Node
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    [IsArgOut]
    public Vector3 xyz { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        xyz = new Vector3((float)args[0], (float)args[1], (float)args[2]);
    }
}
