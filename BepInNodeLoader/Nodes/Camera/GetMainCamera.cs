using System.Xml.Serialization;
using BepInNodeLoader;

namespace TheForestModTwo.Nodes.Camera;

public class GetMainCamera : Node
{
    [XmlIgnore]
    UnityEngine.Camera MainCamera { get; set; }

    [XmlIgnore]
    UnityEngine.Transform CameraTr { get; set; }

    public override void Execute()
    {
        MainCamera = UnityEngine.Camera.main;
        CameraTr = UnityEngine.Camera.main.transform;
    }
}
