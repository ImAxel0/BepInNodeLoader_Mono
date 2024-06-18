using System.Numerics;
using BepInNodeLoader.Core.CoreNodes.Variables.Set;
using BepInNodeLoader.CustomAttributes;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Get;

[IsGetVariable]
public class Vector3Get : Node
{
    [IsArgOut]
    public Vector3 Value { get; set; }

    public override void Execute()
    {
        var setNode = (Vector3Set)ModsData.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
