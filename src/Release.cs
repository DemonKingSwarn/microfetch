using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Src {
public class Release
{
    public static string GetOsPrettyName()
    {
        try
        {
            using (var reader = new StreamReader("/etc/os-release"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("PRETTY_NAME="))
                    {
                        return line.Substring("PRETTY_NAME=".Length).Trim('"');
                    }
                }
            }
            return "Unknown";
        }
        catch (IOException)
        {
            return "Unknown";
        }
    }
}
}
