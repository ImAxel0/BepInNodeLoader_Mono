using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

namespace BepInNodeLoader.Nodes.SceneManager;

public class GetSceneIndex : Node
{
    [XmlIgnore]
    public Scene Scene { get; set; }

    [IsArgOut]
    public int SceneIndex { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var scene = (Scene)args[0];
        SceneIndex = scene.buildIndex;
    }
}
