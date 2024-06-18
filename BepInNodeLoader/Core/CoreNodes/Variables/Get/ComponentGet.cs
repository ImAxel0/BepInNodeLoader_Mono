using BepInNodeLoader.Core.CoreNodes.Variables.Set;
using BepInNodeLoader.CustomAttributes;
using System.Xml.Serialization;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Get;

public class ComponentGet : Node
{
    [IsArgOut]
    [XmlIgnore]
    public UnityEngine.Component Value { get; set; }

    public override void Execute()
    {
        var setNode = (ComponentSet)ModsData.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
