using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.GameObject;

public class FindWithTag : Node
{
    public string Tag { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public UnityEngine.GameObject GameObject { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        GameObject = UnityEngine.GameObject.FindWithTag((string)args[0]);
    }
}
