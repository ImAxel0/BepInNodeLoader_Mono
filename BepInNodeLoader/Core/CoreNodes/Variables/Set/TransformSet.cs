using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Set;

public class TransformSet : Node
{
    [XmlIgnore]
    public UnityEngine.Transform ValueIn { get; set; }

    [IsArgOut]
    [XmlIgnore]
    public UnityEngine.Transform ValueOut { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        ValueOut = (UnityEngine.Transform)args[0];
        ModsData.ReplaceIdNodePair(ModsData.IdNodePair, this.Id, this.Id, this);
    }
}
