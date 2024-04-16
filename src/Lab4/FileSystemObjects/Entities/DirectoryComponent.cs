using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemObjects.Entities;

public class DirectoryComponent : IFileSystemComponent
{
    private readonly List<IFileSystemComponent> _children;

    public DirectoryComponent(string name)
    {
        Name = name;
        _children = new List<IFileSystemComponent>();
    }

    public IReadOnlyList<IFileSystemComponent> Children => _children;
    public string Name { get; }
    public void Accept(IVisitor visitor)
    {
        if (visitor is IVisitor<DirectoryComponent> directoryVisitor)
        {
            directoryVisitor.Visit(this);
        }
    }

    public void Add(IFileSystemComponent component)
    {
        _children.Add(component);
    }

    public void Remove(IFileSystemComponent component)
    {
        _children.Remove(component);
    }
}