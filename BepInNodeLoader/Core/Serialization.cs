using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace BepInNodeLoader.Core;

public class Serialization
{
    public static ModData GetModData(string modPath)
    {
        try
        {
            using (FileStream fileStream = new(modPath, FileMode.Open))
            {
                var derived = GetDerivedTypes(typeof(Node));
                XmlSerializer xmlSerializer = new(typeof(ModData), derived);
                ModData loadedModData = (ModData)xmlSerializer.Deserialize(fileStream);
                return loadedModData;
            }
        }
        catch (Exception ex)
        {
            Utilities.BLogger.BLog.LogError($"Error during deserialization: {ex.Message}");
            return null;
        }
    }

    public static ModData GetModDataFromContent(string modContent)
    {
        try
        {
            using (TextReader reader = new StringReader(modContent))
            {
                var derived = GetDerivedTypes(typeof(Node));
                XmlSerializer xmlSerializer = new(typeof(ModData), derived);
                ModData loadedModData = (ModData)xmlSerializer.Deserialize(reader);
                return loadedModData;
            }
        }
        catch (Exception ex)
        {
            Utilities.BLogger.BLog.LogError($"Error during deserialization: {ex.Message}");
            return null;
        }
    }

    private static Type[] GetDerivedTypes(Type baseType)
    {
        List<Type> derivedTypes = new List<Type>();
        Assembly assembly = Assembly.GetExecutingAssembly();

        foreach (Type type in assembly.GetTypes())
        {
            if (baseType.IsAssignableFrom(type) && type != baseType)
            {
                derivedTypes.Add(type);
            }
        }

        return derivedTypes.ToArray();
    }
}
