using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.Fields;

public class SetVector3FieldValue : Node
{
    [XmlIgnore]
    public UnityEngine.Component Component { get; set; }
    public string FieldName { get; set; }
    public Vector3 Value { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var com = (UnityEngine.Component)args[0];
        var field = com.GetType().GetField((string)args[1], System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
        var value = (Vector3)args[2];
        field.SetValue(com, new UnityEngine.Vector3(value.X, value.Y, value.Z));
    }
}
