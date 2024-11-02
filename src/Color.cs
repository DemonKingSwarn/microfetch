using System;

namespace Src {
  public static class Color
  {
      public const string RESET = "\x1b[0m";
      public const string BLUE = "\x1b[34m";
      public const string CYAN = "\x1b[36m";
      public const string GREEN = "\x1b[32m";
      public const string YELLOW = "\x1b[33m";
      public const string RED = "\x1b[31m";
      public const string MAGENTA = "\x1b[35m";

      public static string PrintDots()
      {
          return $"{BLUE}  {CYAN}  {GREEN}  {YELLOW}  {RED}  {MAGENTA}  {RESET}";
      }
  }
}
