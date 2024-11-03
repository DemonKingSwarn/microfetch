using System;
using System.IO;

namespace Src {
public static class Memory
{
    public static string GetMemory()
    {
        long totalMemory = 0;
        long availableMemory = 0;

        try
        {
            foreach (var line in File.ReadLines("/proc/meminfo"))
            {
                if (line.StartsWith("MemTotal:"))
                {
                    // Extract the numerical value (in KiB) directly
                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 2 && long.TryParse(parts[1], out totalMemory))
                    {
                        // Successfully parsed total memory
                    }
                }
                else if (line.StartsWith("MemAvailable:"))
                {
                    // Extract the numerical value (in KiB) directly
                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 2 && long.TryParse(parts[1], out availableMemory))
                    {
                        // Successfully parsed available memory
                    }
                }

                if (totalMemory > 0 && availableMemory > 0)
                {
                    break;
                }
            }

            // Calculate used memory
            long usedMemory = totalMemory - availableMemory;

            // Convert from KiB to GiB
            double totalMemoryGiB = totalMemory / (1024.0 * 1024.0);
            double usedMemoryGiB = usedMemory / (1024.0 * 1024.0);

            // Calculate usage percentage
            double usagePercentage = (double)usedMemory / totalMemory * 100;

            return $"{usedMemoryGiB:F2} GiB / {totalMemoryGiB:F2} GiB ({usagePercentage:F1}%)";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }
    
}
}
