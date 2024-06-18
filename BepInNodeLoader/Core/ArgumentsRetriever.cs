using BepInNodeLoader.CustomAttributes;
using System.Collections.Generic;
using System.Linq;

namespace BepInNodeLoader.Core;

public class ArgumentsRetriever
{
    public static List<object> GetArgumentsOf(Node thisNode)
    {
        List<object> args = new();

        int argIdx = 0;
        thisNode.ArgsIn.ForEach(argIn => {

            if (!argIn.HasConnection)
            {
                args.Add(thisNode.GetType().GetProperties().Where(p => p.DeclaringType == thisNode.GetType()).ElementAt(argIdx).GetValue(thisNode, null));
            }
            else
            {
                Node node = ModsData.GetNodeById(argIn.ReceiveFrom);
                var prop = node.GetType().GetProperties().Where(p => p.DeclaringType == node.GetType()
                && p.GetCustomAttributes(typeof(IsArgOut), false).Any());

                args.Add(prop.ElementAt(argIn.ReceiveFromIndex).GetValue(node, null));
            }
            argIdx++;
        });

        return args;
    }
}
