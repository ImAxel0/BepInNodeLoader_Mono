using BepInNodeLoader.NodeArguments;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BepInNodeLoader;

public class Node
{
    public string Id;

    [XmlArray("ArgsIn"), XmlArrayItem(typeof(ArgIn))]
    public List<ArgIn> ArgsIn = new();

    [XmlArray("ArgsOut"), XmlArrayItem(typeof(ArgOut))]
    public List<ArgOut> ArgsOut = new();

    public virtual void Execute()
    {
        Utilities.BLogger.BLog.LogInfo("Node executed");
    }

    public virtual bool Execute(string args)
    {
        Utilities.BLogger.BLog.LogInfo("Node executed");
        return true;
    }
}
