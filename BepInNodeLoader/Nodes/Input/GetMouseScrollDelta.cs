using BepInNodeLoader.CustomAttributes;
using System.Numerics;

namespace BepInNodeLoader.Nodes.Input;

public class GetMouseScrollDelta : Node
{
    [IsArgOut]
    public Vector2 ScrollDelta { get; set; }

    public override void Execute()
    {
        var pos = UnityEngine.Input.mouseScrollDelta;
        ScrollDelta = new Vector2(pos.x, pos.y);
    }
}
