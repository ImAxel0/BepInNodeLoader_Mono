using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.Flow;

public class If : Node
{
    public bool Value { get; set; }

    [XmlArray("TrueBranch")]
    [XmlArrayItem("Node", typeof(Node))]
    public List<Node> TrueBranchNodes { get; set; } = new List<Node>();

    [XmlArray("FalseBranch")]
    [XmlArrayItem("Node", typeof(Node))]
    public List<Node> FalseBranchNodes { get; set; } = new List<Node>();

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        if ((bool)args[0])
        {
            TrueBranchNodes.ForEach(node => node.Execute());
        }
        else
        {
            FalseBranchNodes.ForEach(node => node.Execute());
        }
    }
}
