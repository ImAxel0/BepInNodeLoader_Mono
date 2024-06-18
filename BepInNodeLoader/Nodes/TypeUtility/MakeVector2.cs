using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.TypeUtility;

public class MakeVector2 : Node
{
    public float X { get; set; }
    public float Y { get; set; }

    [IsArgOut]
    public Vector2 xyz { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        xyz = new Vector2((float)args[0], (float)args[1]);
    }
}
