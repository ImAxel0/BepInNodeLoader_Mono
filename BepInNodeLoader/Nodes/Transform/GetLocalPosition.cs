using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Transform;

public class GetLocalPosition : Node
{
    [IsArgOut]
    public Vector3 LocalPosition { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var tr = (UnityEngine.Transform)args[0];
        LocalPosition = new Vector3(tr.localPosition.x, tr.localPosition.y, tr.localPosition.z);
    }
}
