using BepInNodeLoader.Core;
using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader.Nodes.GameObject;

public class GoGetComponentInChildren : Node
{
    [XmlIgnore]
    public UnityEngine.GameObject GameObject { get; set; }
    public string ComponentName { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public UnityEngine.Component Component { get; set; }

    public override void Execute()
    {
        List<object> args = ArgumentsRetriever.GetArgumentsOf(this);
        var go = (UnityEngine.GameObject)args[0];

        GetAllChidren(go.transform, Children);
        foreach (var child in Children)
        {
            var cmp = child.GetComponent((string)args[1]);

            if (cmp)
            {
                Component = cmp;
                break;
            }
        }
        Children.Clear();
    }

    List<UnityEngine.Transform> Children = new();
    private void GetAllChidren(UnityEngine.Transform parent, List<UnityEngine.Transform> list)
    {
        for (int i = 0; i < parent.GetChildCount(); i++)
        {
            var child = parent.GetChild(i);
            list.Add(child.transform);
            GetAllChidren(child, list);
        }
    }
}
