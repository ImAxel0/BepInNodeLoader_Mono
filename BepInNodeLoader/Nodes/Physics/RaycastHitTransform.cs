﻿using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace BepInNodeLoader.Nodes.Physics;

public class RaycastHitTransform : Node
{
    [XmlIgnore]
    [IsArgOut]
    public UnityEngine.Transform Transform { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var hitInfo = (RaycastHit)args[0];
        Transform = hitInfo.transform;
    }
}
