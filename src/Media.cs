using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Src
{
    public class Media
    {
        public static string GetMediaInfo()
        {
            string title = null;
            string artist = null;

            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "playerctl",
                        Arguments = "metadata",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                var titleMatch = Regex.Match(output, @"xesam:title\s+(.+)");
                var artistMatch = Regex.Match(output, @"xesam:artist\s+(.+)");

                if (titleMatch.Success)
                {
                    title = titleMatch.Groups[1].Value.Trim();
                }

                if (artistMatch.Success)
                {
                    artist = artistMatch.Groups[1].Value.Trim();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return $"{title ?? "Unknown Title"} - {artist ?? "Unknown Artist"}";
        }
    }
}

