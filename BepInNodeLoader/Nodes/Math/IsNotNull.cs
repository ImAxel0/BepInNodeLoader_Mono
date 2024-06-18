using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.Math;

public class IsNotNull : Node
{
    [IsArgOut]
    public bool Result { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        Result = args[0] != null;
    }
}
