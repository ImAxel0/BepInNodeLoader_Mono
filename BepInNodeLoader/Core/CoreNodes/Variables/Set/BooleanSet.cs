using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;

namespace BepInNodeLoader.Core.CoreNodes.Variables.Set;

public class BooleanSet : Node
{
    public bool ValueIn { get; set; }

    [IsArgOut]
    public bool ValueOut { get; set; }
    
    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        ValueOut = (bool)args[0];
        ModsData.ReplaceIdNodePair(ModsData.IdNodePair, this.Id, this.Id, this);
    }
}
