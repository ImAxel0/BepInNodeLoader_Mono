using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Transform;

public class GetLocalRotation : Node
{
    [IsArgOut]
    public Vector3 LocalRotation { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var tr = (UnityEngine.Transform)args[0];
        LocalRotation = new Vector3(tr.localRotation.x, tr.localRotation.y, tr.localRotation.z);
    }
}
