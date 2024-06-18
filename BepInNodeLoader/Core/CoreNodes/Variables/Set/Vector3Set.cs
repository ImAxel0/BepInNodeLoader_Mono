using BepInNodeLoader.CustomAttributes;
using System.Numerics;
using System.Collections.Generic;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Set;

public class Vector3Set : Node
{
    public Vector3 ValueIn { get; set; }

    [IsArgOut]
    public Vector3 ValueOut { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        ValueOut = (Vector3)args[0];
        ModsData.ReplaceIdNodePair(ModsData.IdNodePair, this.Id, this.Id, this);
    }
}
