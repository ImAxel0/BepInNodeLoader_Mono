using BepInNodeLoader.Core.CoreNodes.Variables.Set;
using BepInNodeLoader.CustomAttributes;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Get;

[IsGetVariable]
public class ObjectGet : Node
{
    [IsArgOut]
    public object Value { get; set; } = null;

    public override void Execute()
    {
        var setNode = (ObjectSet)ModsData.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
