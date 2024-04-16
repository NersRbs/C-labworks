using Itmo.ObjectOrientedProgramming.Lab4.FileSystemObjects.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models.Visitors;

public interface IVisitor { }

public interface IVisitor<T> : IVisitor
    where T : IFileSystemComponent
{
    void Visit(T command);
}