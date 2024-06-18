using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Set;

public class ComponentSet : Node
{
    [XmlIgnore]
    public UnityEngine.Component ValueIn { get; set; }

    [IsArgOut]
    [XmlIgnore]
    public UnityEngine.Component ValueOut { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        ValueOut = (UnityEngine.Component)args[0];
        ModsData.ReplaceIdNodePair(ModsData.IdNodePair, this.Id, this.Id, this);
    }
}
