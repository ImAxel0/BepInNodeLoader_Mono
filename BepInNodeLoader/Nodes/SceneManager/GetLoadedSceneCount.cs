using BepInNodeLoader.CustomAttributes;
using BepInNodeLoader.Utilities;

namespace BepInNodeLoader.Nodes.SceneManager;

public class GetLoadedSceneCount : Node
{
    [IsArgOut]
    public int SceneCount { get; set; }

    public override void Execute()
    {
        //SceneCount = UnityEngine.SceneManagement.SceneManager.loadedSceneCount;
        BLogger.BLog.LogWarning("GetLoadedSceneCount isn't supported");
    }
}
