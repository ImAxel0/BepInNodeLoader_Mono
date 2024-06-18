using BepInNodeLoader.Core.CoreNodes.Variables.Set;
using BepInNodeLoader.CustomAttributes;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Get;

[IsGetVariable]
public class StringGet : Node
{
    [IsArgOut]
    public string Value { get; set; }

    public override void Execute()
    {
        var setNode = (StringSet)ModsData.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
