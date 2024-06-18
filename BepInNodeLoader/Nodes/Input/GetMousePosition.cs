using BepInNodeLoader.CustomAttributes;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Input;

public class GetMousePosition : Node
{
    [IsArgOut]
    public Vector3 Position { get; set; }

    public override void Execute()
    {
        var pos = UnityEngine.Input.mousePosition;
        Position = new Vector3(pos.x, pos.y, pos.z);
    }
}
