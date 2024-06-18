using BepInNodeLoader.Core.CoreNodes.Variables.Set;
using BepInNodeLoader.CustomAttributes;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Get;

[IsGetVariable]
public class IntGet : Node
{
    [IsArgOut]
    public int Value { get; set; }

    public override void Execute()
    {
        var setNode = (IntSet)ModsData.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
