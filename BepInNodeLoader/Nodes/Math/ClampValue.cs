using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using UnityEngine;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.Math;

public class ClampValue : Node
{
    public float Value { get; set; }
    public float Min { get; set; }
    public float Max { get; set; }

    [IsArgOut]
    public float Result { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        Result = Mathf.Clamp((float)args[0], (float)args[1], (float)args[2]);
    }
}
