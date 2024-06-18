using BepInEx;
using BepInNodeLoader.Core;
using BepInNodeLoader.Core.NodeActions;
using BepInNodeLoader.Core.Runtime;
using BepInNodeLoader.Utilities;

namespace BepInNodeLoader;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        // Plugin startup logic
        BLogger.BLog = BepInEx.Logging.Logger.CreateLogSource("BepInNodeLogger");
        BLogger.BLog.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        PipeManager.WaitForConnection();
        ModsData.SetupMods();
        ModsData.LoadMods();

        // execute all OnLoad nodes
        ModsData.AllModsData.ForEach(mod =>
        {
            mod.OnLoad.ForEach(node =>
            {
                node.Execute();
            });
        });

        // injecting MonoBehaviours
        var BepInEx_Manager = UnityEngine.GameObject.Find("BepInEx_Manager");
        if (BepInEx_Manager)
        {
            if (!BepInEx_Manager.GetComponent<OnUpdate>())
            {
                BepInEx_Manager.AddComponent<OnUpdate>();
                BLogger.BLog.LogInfo("OnUpdate Injected!");
            }
            if (!BepInEx_Manager.GetComponent<OnFixedUpdate>())
            {
                BepInEx_Manager.AddComponent<OnFixedUpdate>();
                BLogger.BLog.LogInfo("OnFixedUpdate Injected!");
            }
        }
        else BLogger.BLog.LogError("Couldn't inject node actions, BepInNode mods won't work");
    }
}
