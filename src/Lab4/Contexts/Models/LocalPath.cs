using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

public class LocalPath : IPath
{
    private readonly List<string> _parts;
    public LocalPath(string path)
    {
        _parts = path.Split(Path.DirectorySeparatorChar).ToList();
    }

    public string GetPath()
    {
        return string.Join(Path.DirectorySeparatorChar.ToString(), _parts);
    }

    public override string ToString()
    {
        return GetPath();
    }
}