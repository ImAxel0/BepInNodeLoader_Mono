using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Set;

public class GameObjectSet : Node
{
    [XmlIgnore]
    public UnityEngine.GameObject ValueIn { get; set; }

    [IsArgOut]
    [XmlIgnore]
    public UnityEngine.GameObject ValueOut { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        ValueOut = (UnityEngine.GameObject)args[0];
        ModsData.ReplaceIdNodePair(ModsData.IdNodePair, this.Id, this.Id, this);
    }
}
