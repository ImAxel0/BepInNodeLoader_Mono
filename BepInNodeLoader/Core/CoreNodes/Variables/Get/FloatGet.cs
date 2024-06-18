using BepInNodeLoader.Core.CoreNodes.Variables.Set;
using BepInNodeLoader.CustomAttributes;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Get;

[IsGetVariable]
public class FloatGet : Node
{
    [IsArgOut]
    public float Value { get; set; }

    public override void Execute()
    {
        var setNode = (FloatSet)ModsData.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
