using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts.Entities;

public class Context : IContext
{
    public IPath Address { get; set; } = new LocalPath(" ");
    public IFileSystem FileSystem { get; set; } = new NullFileSystem();
}