using Src;

class Program
{
    static void Main()
    {
        Console.WriteLine($"{Release.GetUserAndHost()}");
        Console.WriteLine($"  System\t| {Release.GetOsPrettyName()}");
        Console.WriteLine($"  Kernel\t| {Release.GetSystemInfo()}");
        Console.WriteLine($"  Shell\t| {Shell.GetDefaultShell()}");
        Console.WriteLine($"  Terminal\t| {Terminal.GetDefaultTerm()}");
        Console.WriteLine($"  Uptime\t| {Release.Uptime()}");
        Console.WriteLine($"  Desktop\t| {Desktop.DesktopInfo()}");
        Console.WriteLine($"塞 Memory\t| {Memory.GetMemory()}");
        Console.WriteLine($"  Media\t| {Media.GetMediaInfo()}");
        Console.WriteLine($"  Colors\t| {Color.PrintDots()}");
    }
}

