using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.TypeUtility;

public class FloatToInt : Node
{
    [IsArgOut]
    public int Converted { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        Converted = Convert.ToInt32((float)args[0]);
    }
}
