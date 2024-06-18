using BepInNodeLoader.Core.CoreNodes.Variables.Set;
using BepInNodeLoader.CustomAttributes;
using System.Xml.Serialization;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Get;

public class RigidbodyGet : Node
{
    [IsArgOut]
    [XmlIgnore]
    public UnityEngine.Rigidbody Value { get; set; }

    public override void Execute()
    {
        var setNode = (RigidbodySet)ModsData.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
