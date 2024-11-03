using System;
using Src;

class Program
{
    static void Main()
    {
        Console.WriteLine($"{Release.GetUserAndHost()}");
        Console.WriteLine($"System\t| {Release.GetOsPrettyName()}");
        Console.WriteLine($"Kernel\t| {Release.GetSystemInfo()}");
        Console.WriteLine($"Shell\t| {Shell.GetDefaultShell()}");
        Console.WriteLine($"Desktop\t| {Desktop.DesktopInfo()}");
        Console.WriteLine($"Colors\t| {Color.PrintDots()}");
    }
}
