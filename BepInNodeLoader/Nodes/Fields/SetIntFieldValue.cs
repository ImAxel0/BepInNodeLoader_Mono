using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.Fields;

public class SetIntFieldValue : Node
{
    [XmlIgnore]
    public UnityEngine.Component Component { get; set; }
    public string FieldName { get; set; }
    public int Value { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var com = (UnityEngine.Component)args[0];
        var field = com.GetType().GetField((string)args[1], System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
        field.SetValue(com, (int)args[2]);
    }
}
