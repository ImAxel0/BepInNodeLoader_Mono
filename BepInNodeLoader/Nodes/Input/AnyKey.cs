using BepInNodeLoader.CustomAttributes;

namespace BepInNodeLoader.Nodes.Input;

public class AnyKey : Node
{
    [IsArgOut]
    public bool Result { get; set; }

    public override void Execute()
    {
        Result = UnityEngine.Input.anyKey;
    }
}
