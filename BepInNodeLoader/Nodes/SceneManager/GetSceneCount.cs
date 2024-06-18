using BepInNodeLoader.CustomAttributes;

namespace BepInNodeLoader.Nodes.SceneManager;

public class GetSceneCount : Node
{
    [IsArgOut]
    public int SceneCount { get; set; }

    public override void Execute()
    {
        SceneCount = UnityEngine.SceneManagement.SceneManager.sceneCount;
    }
}
