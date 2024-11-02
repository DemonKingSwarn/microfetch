using System;
using Src;

class Program
{
    static void Main()
    {
        Console.WriteLine($"System: {Release.GetOsPrettyName()}");
        Console.WriteLine($"Desktop: {Desktop.DesktopInfo()}");
        Console.WriteLine(Color.PrintDots());
    }
}
