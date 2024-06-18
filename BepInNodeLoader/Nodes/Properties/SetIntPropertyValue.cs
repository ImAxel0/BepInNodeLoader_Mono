﻿using System.Xml.Serialization;
using UnityEngine;
using System.Collections.Generic;
using BepInNodeLoader.Core;

namespace BepInNodeLoader.Generics;

public class SetIntPropertyValue : Node
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string PropertyName { get; set; }
    public int Value { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var com = (Component)args[0];
        var property = com.GetType().GetProperty((string)args[1], System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
        property.SetValue(com, (int)args[2], null);
    }
}