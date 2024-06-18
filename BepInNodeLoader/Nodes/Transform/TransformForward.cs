using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Transform;

public class TransformForward : Node
{
    [IsArgOut]
    public Vector3 Forward { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var tr = (UnityEngine.Transform)args[0];
        Forward = new Vector3(tr.forward.x, tr.forward.y, tr.forward.z);
    }
}
