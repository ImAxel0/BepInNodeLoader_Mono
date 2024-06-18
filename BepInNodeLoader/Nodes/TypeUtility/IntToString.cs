using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.TypeUtility;

public class IntToString : Node
{
    [IsArgOut]
    public string Converted { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        Converted = Convert.ToString((int)args[0]);
    }
}
