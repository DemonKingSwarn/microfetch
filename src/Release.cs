using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Src {
  public class Release
  {
      const string GREEN = "\x1b[32m";
      const string RED = "\x1b[31m";
      const string YELLOW = "\x1b[33m";
      const string RESET = "\x1b[0m";
      
      public static string GetUserAndHost()
      {         
        string userEnv = Environment.GetEnvironmentVariable("USER");
        //string hostEnv = Environment.GetEnvironmentVariable("HOST");
        string hostEnv;
        try
        {
            hostEnv = File.ReadAllText("/etc/hostname").Trim();
        }
        catch (Exception)
        {
            hostEnv = "unknown";
        }

        string userAndHost = $"{YELLOW}{userEnv}{RED}@{GREEN}{hostEnv}{RESET}";
        return userAndHost;
      }

      public static string GetSystemInfo()
      {
        using (Process process = new Process())
        {
          process.StartInfo.FileName = "/bin/sh";
          process.StartInfo.Arguments = "-c \"uname -mrs\"";
          process.StartInfo.RedirectStandardOutput = true;
          process.StartInfo.UseShellExecute = false;
          process.StartInfo.CreateNoWindow = true;

          process.Start();
          string output = process.StandardOutput.ReadToEnd();
          process.WaitForExit();

          string[] parts = output.Split(' ');
          if (parts.Length >= 3)
          {
            string sysname = parts[0].Trim();
            string release = parts[1].Trim();
            string machine = parts[2].Trim();

            return $"{sysname} {release} ({machine})";
          }

          return output;
        }
      }

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

      public static string Uptime()
      {
        using (Process process = new Process())
        {
          process.StartInfo.FileName = "/bin/sh";
          process.StartInfo.Arguments = "-c \"uptime -p\"";
          process.StartInfo.RedirectStandardOutput = true;
          process.StartInfo.UseShellExecute = false;
          process.StartInfo.CreateNoWindow = true;

          process.Start();
          string output = process.StandardOutput.ReadToEnd().Trim();
          process.WaitForExit();

          if (output.StartsWith("up "))
          {
            output = output.Substring(3);
          }

          return output;
        }
      }
  }
}
