using System;

namespace Src {

  public class Shell {
    public static string GetDefaultShell()
    {
      string shellEnv = Environment.GetEnvironmentVariable("SHELL");
      return shellEnv.Split('/')[3];
    }
  }
  
}
