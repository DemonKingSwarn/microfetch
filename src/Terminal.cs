namespace Src {

  public class Terminal {
    public static string GetDefaultTerm()
    {
      string termEnv = Environment.GetEnvironmentVariable("TERM_PROGRAM");
      string termVerEnv = Environment.GetEnvironmentVariable("TERM_PROGRAM_VERSION");
      return $"{termEnv} ({termVerEnv})";
    }
  }
  
}
