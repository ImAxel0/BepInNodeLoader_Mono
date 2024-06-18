using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.Input;

public class GetAxisRaw : Node
{
    public string AxisName { get; set; }

    [IsArgOut]
    public float AxisValue { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        AxisValue = UnityEngine.Input.GetAxisRaw((string)args[0]);
    }
}
