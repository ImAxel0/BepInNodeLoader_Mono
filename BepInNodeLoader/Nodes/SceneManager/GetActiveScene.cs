using BepInNodeLoader.CustomAttributes;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

namespace BepInNodeLoader.Nodes.SceneManager;

public class GetActiveScene : Node
{
    [XmlIgnore]
    [IsArgOut]
    public Scene Scene { get; set; }

    public override void Execute()
    {
        Scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }
}
