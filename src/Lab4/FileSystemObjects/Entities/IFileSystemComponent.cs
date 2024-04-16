using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemObjects.Entities;

public interface IFileSystemComponent
{
    string Name { get; }
    void Accept(IVisitor visitor);
}