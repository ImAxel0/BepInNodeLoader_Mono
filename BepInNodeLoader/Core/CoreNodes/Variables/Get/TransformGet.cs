using BepInNodeLoader.Core.CoreNodes.Variables.Set;
using BepInNodeLoader.CustomAttributes;
using System.Xml.Serialization;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Get;

public class TransformGet : Node
{
    [IsArgOut]
    [XmlIgnore]
    public UnityEngine.Transform Value { get; set; }

    public override void Execute()
    {
        var setNode = (TransformSet)ModsData.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
