using BepInNodeLoader.Core;
using System.Collections.Generic;

namespace BepInNodeLoader.Nodes.SceneManager;

public class UnloadSceneAsync : Node
{
    public string SceneName { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync((string)args[0]);
    }
}
