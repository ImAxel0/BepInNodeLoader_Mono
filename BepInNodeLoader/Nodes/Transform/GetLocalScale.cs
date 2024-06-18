using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Transform;

public class GetLocalScale : Node
{
    [IsArgOut]
    public Vector3 LocalScale { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var tr = (UnityEngine.Transform)args[0];
        LocalScale = new Vector3(tr.localScale.x, tr.localScale.y, tr.localScale.z);
    }
}
