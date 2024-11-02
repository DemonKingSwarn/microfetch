using System;

namespace Src {
  public class Desktop 
  {
    public static string DesktopInfo()
    {
      string desktopEnv = Environment.GetEnvironmentVariable("XDG_CURRENT_DESKTOP");
      string displayBackend = Environment.GetEnvironmentVariable("XDG_SESSION_TYPE");

      if (!string.IsNullOrEmpty(displayBackend))
      {
        displayBackend = char.ToUpper(displayBackend[0]) + displayBackend.Substring(1);
      }

      desktopEnv = desktopEnv.StartsWith("none+") ? desktopEnv.Substring(5) : desktopEnv;

      if (string.IsNullOrEmpty(displayBackend))
      {
        displayBackend = "Unknown";
      }

     return $"{desktopEnv} ({displayBackend})";
    }
  }
}
