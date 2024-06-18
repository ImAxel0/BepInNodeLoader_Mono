using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using BepInNodeLoader.Utilities;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.Transform;

public class GetRoot : Node
{
    [XmlIgnore]
    [IsArgOut]
    public UnityEngine.Transform RootTr { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var tr = (UnityEngine.Transform)args[0];
        BLogger.BLog.LogWarning("GetRoot isn't supported");
        //RootTr = tr.GetRoot();
    }
}
