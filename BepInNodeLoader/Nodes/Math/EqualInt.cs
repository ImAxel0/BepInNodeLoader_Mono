﻿using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.Math;

public class EqualInt : Node
{
    public int First { get; set; }
    public int Second { get; set; }

    [IsArgOut]
    public bool Result { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        Result = (int)args[0] == (int)args[1];
    }
}
