using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.TypeUtility;

public class IntToFloat : Node
{
    [IsArgOut]
    public float Converted { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        Converted = (float)Convert.ToDouble((int)args[0]);
    }
}
