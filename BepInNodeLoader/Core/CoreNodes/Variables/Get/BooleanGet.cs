using BepInNodeLoader.Core.CoreNodes.Variables.Set;
using BepInNodeLoader.CustomAttributes;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Get;

[IsGetVariable]
public class BooleanGet : Node
{
    [IsArgOut] 
    public bool Value { get; set; }

    public override void Execute()
    {
        var setNode = (BooleanSet)ModsData.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
