using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models.FileShowMods;

public class ConsoleFileShowMode : IFileShowMode
{
    public void Show(string content)
    {
        Console.WriteLine(content);
    }
}