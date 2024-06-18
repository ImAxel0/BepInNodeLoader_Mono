using System.Numerics;
using BepInNodeLoader.CustomAttributes;
using System;
using System.Collections.Generic;
using BepInNodeLoader.Core;

namespace BepInNodeLoader.Nodes.TypeUtility;

public class Vec3ToString : Node
{
    [IsArgOut]
    public string Converted { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        Converted = Convert.ToString((Vector3)args[0]);
    }
}
