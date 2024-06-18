using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.Events;

public class CustomEvent : Node
{
    public string EventId { get; set; }
    public string EventName { get; set; }

    [XmlArray("EventNodes")]
    [XmlArrayItem("Node", typeof(Node))]
    public List<Node> EventNodes { get; set; } = new List<Node>();

    public override void Execute()
    {
        EventNodes.ForEach(node => node.Execute());
    }

    public override bool Execute(string args)
    {
        EventNodes.ForEach(node => node.Execute());
        return true;
    }
}
