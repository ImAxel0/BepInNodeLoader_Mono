using System.Xml.Serialization;
using UnityEngine;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using BepInNodeLoader.Core;

namespace BepInNodeLoader.Generics;

public class GetFloatPropertyValue : Node
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string PropertyName { get; set; }

    [IsArgOut]
    public float Value { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var com = (Component)args[0];
        var property = com.GetType().GetProperty((string)args[1], System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
        Value = (float)property.GetValue(com, null);
    }
}
