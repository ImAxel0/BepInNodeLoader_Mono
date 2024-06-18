using BepInNodeLoader.Core;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.GameObject;

public class DestroyGameObject : Node
{
    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        UnityEngine.GameObject.Destroy((UnityEngine.GameObject)args[0]);
    }
}
