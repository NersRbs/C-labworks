using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemObjects.Entities;

public class FileComponent : IFileSystemComponent
{
    public FileComponent(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public void Accept(IVisitor visitor)
    {
        if (visitor is IVisitor<FileComponent> fileVisitor)
        {
            fileVisitor.Visit(this);
        }
    }
}