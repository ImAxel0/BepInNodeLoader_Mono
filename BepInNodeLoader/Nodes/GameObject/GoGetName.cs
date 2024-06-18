using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.GameObject;

public class GoGetName : Node
{
    [IsArgOut]
    public string Name { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var go = (UnityEngine.GameObject)args[0];
        Name = go.name;
    }
}
