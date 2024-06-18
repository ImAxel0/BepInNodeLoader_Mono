using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Transform;

public class TransformUp : Node
{
    [IsArgOut]
    public Vector3 Up { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var tr = (UnityEngine.Transform)args[0];
        Up = new Vector3(tr.up.x, tr.up.y, tr.up.z);
    }
}
