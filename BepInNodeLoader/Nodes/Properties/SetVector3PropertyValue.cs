using BepInNodeLoader.Core;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.Properties;

public class SetVector3PropertyValue : Node
{
    [XmlIgnore]
    public UnityEngine.Component Component { get; set; }
    public string PropertyName { get; set; }
    public float Value { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var com = (UnityEngine.Component)args[0];
        var property = com.GetType().GetProperty((string)args[1], System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
        var value = (Vector3)args[2];
        property.SetValue(com, new UnityEngine.Vector3(value.X, value.Y, value.Z), null);
    }
}
