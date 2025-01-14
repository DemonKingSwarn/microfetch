using System;
using System.IO;

namespace Src {
public static class Storage
{
    public static string GetStorage()
    {
       string rootPath = "/";

       long totalSpace = 0;
       long freeSpace = 0;
       long usedSpace = 0;

       double totalSpaceGiB = 0;
       double usedSpaceGiB = 0;

       double usedPercentage = 0;

       try 
       {
          DriveInfo drive = new DriveInfo(rootPath);

          if(drive.IsReady)
          {
            totalSpace = drive.TotalSize;
            freeSpace = drive.TotalFreeSpace;
            usedSpace = totalSpace - freeSpace;
          }
       }
       catch(Exception ex)
       {
          Console.WriteLine($"An error occured: {ex.Message}");
       }

       totalSpaceGiB = totalSpace / (1024.0 * 1024.0 * 1024.0);
       usedSpaceGiB = usedSpace / (1024.0 * 1024.0 * 1024.0);

        usedPercentage = (usedSpaceGiB / totalSpaceGiB) * 100d;

            string green = "\x1b[0;32m";
            string yellow = "\x1b[1;33m";
            string red = "\x1b[0;31m";
            string reset = "\x1b[0m";
            
            string colorCode;

            if(usedPercentage < 50d)
            {
              colorCode = green;
            }
            else if(usedPercentage >= 50d && usedPercentage < 89d)
            {
              colorCode = yellow;
            }
            else {
              colorCode = red;
            }

            string storageUsage;
            storageUsage = $"{colorCode}{usedPercentage:0.00}%{reset}";

       return $"{usedSpaceGiB:F1} GiB / {totalSpaceGiB:F1} GiB ({storageUsage})";
    }
    
}
}
