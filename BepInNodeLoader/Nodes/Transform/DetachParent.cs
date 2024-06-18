using BepInNodeLoader.Core;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.Transform;

public class DetachParent : Node
{
    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var tr = (UnityEngine.Transform)args[0];
        tr.SetParent(null);
    }
}
