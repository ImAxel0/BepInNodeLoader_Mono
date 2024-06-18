using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.Transform;

public class GetParent : Node
{
    [XmlIgnore]
    [IsArgOut]
    public UnityEngine.Transform ParentTr { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var tr = (UnityEngine.Transform)args[0];
        //ParentTr = tr.GetParent();
    }
}
