using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.Input;

public class GetKeyDown : Node
{
    public UnityEngine.KeyCode EnumValue { get; set; }

    [IsArgOut]
    public bool WasPressed { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        WasPressed = UnityEngine.Input.GetKeyDown((UnityEngine.KeyCode)args[0]);
    }
}
