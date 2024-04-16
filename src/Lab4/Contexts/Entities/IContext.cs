using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts.Entities;

public interface IContext
{
    public IPath Address { get; set; }
    public IFileSystem FileSystem { get; set; }
}