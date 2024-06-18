using BepInNodeLoader.CustomAttributes;

namespace BepInNodeLoader.Nodes.Input;

public class AnyKeyDown : Node
{
    [IsArgOut]
    public bool Result { get; set; }

    public override void Execute()
    {
        Result = UnityEngine.Input.anyKeyDown;
    }
}
