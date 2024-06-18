using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.GameObject;

public class InstantiateGameObject : Node
{
    [XmlIgnore]
    public UnityEngine.GameObject GameObject { get; set; }
    public Vector3 Pos { get; set; }
    public Vector3 Rot { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public UnityEngine.GameObject Instantiated { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var go = (UnityEngine.GameObject)args[0];
        var pos = (Vector3)args[1];
        var rot = (Vector3)args[2];
        Instantiated = UnityEngine.Object.Instantiate(go, new UnityEngine.Vector3(pos.X, pos.Y, pos.Z), 
            UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(rot.X, rot.Y, rot.Z)));
    }
}
