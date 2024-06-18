using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.Rigidbody;

public class RbIsKinematic : Node
{
    [IsArgOut]
    public bool IsKinematic { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var rb = (UnityEngine.Rigidbody)args[0];
        IsKinematic = rb.isKinematic;
    }
}
