using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemObjects.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models.Visitors;

public class TreeVisitor : IVisitor<FileComponent>, IVisitor<DirectoryComponent>
{
    private int _depth;
    public void Visit(FileComponent command)
    {
        string indent = new string(' ', _depth * 2);
        Console.WriteLine($"{indent}{command.Name}");
    }

    public void Visit(DirectoryComponent command)
    {
        string indent = new string(' ', _depth * 2);
        Console.WriteLine($"{indent}{command.Name}");

        _depth++;
        foreach (IFileSystemComponent child in command.Children)
        {
            child.Accept(this);
        }

        _depth--;
    }
}