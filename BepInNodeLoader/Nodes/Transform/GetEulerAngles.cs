using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Transform;

public class GetEulerAngles : Node
{
    [IsArgOut]
    public Vector3 EulerAngles { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var tr = (UnityEngine.Transform)args[0];
        var v3 = new Vector3(tr.eulerAngles.x, tr.eulerAngles.y, tr.eulerAngles.z);
        EulerAngles = v3;
    }
}
