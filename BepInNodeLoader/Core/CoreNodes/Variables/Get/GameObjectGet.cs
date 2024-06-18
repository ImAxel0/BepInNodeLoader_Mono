using BepInNodeLoader.Core.CoreNodes.Variables.Set;
using BepInNodeLoader.CustomAttributes;
using System.Xml.Serialization;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Get;

public class GameObjectGet : Node
{
    [IsArgOut]
    [XmlIgnore]
    public UnityEngine.GameObject Value { get; set; }

    public override void Execute()
    {
        var setNode = (GameObjectSet)ModsData.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
