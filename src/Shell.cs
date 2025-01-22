namespace Src {

  public class Shell {
    public static string GetDefaultShell()
    {
      string shellEnv = Environment.GetEnvironmentVariable("SHELL");
      string[] parts = shellEnv.Split('/');
      return parts.Length > 0 ? parts[^1] : string.Empty;
    }
  }
  
}
