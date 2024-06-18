using System.Collections.Generic;
using System.Xml.Serialization;
using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;

namespace BepInNodeLoader.Nodes.GameObject;

public class FindGameObject : Node
{
    public string name { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public UnityEngine.GameObject GameObject { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        GameObject = UnityEngine.GameObject.Find((string)args[0]);
    }
}
