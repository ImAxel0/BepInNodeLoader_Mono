using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

namespace BepInNodeLoader.Nodes.SceneManager;

public class IsSceneLoaded : Node
{
    [XmlIgnore]
    public Scene Scene { get; set; }

    [IsArgOut]
    public bool IsLoaded { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var scene = (Scene)args[0];
        IsLoaded = scene.isLoaded;
    }
}
