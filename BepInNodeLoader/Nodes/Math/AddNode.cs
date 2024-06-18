using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.Math;

public class AddNode : Node
{
    public float First { get; set; }
    public float Second { get; set; }

    [IsArgOut]
    public float Result { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        Result = (float)args[0] + (float)args[1];
    }
}
