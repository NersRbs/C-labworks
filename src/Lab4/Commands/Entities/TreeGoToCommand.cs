using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class TreeGoToCommand : ICommand
{
    private readonly IPath _path;
    private TreeGoToCommand(IPath path)
    {
        _path = path;
    }

    public static TreeGoToCommandBuilder Builder => new();

    public CommandStatus Execute(IContext context)
    {
        bool isAbsolutePath = Path.IsPathRooted(_path.GetPath());
        string fullPath = isAbsolutePath ? _path.GetPath() : Path.GetFullPath(Path.Combine(context.Address.GetPath(), _path.GetPath()));
        fullPath = Path.GetFullPath(fullPath);
        if (!Directory.Exists(fullPath))
        {
            return CommandStatus.DirectoryNotFound;
        }

        context.Address = new LocalPath(fullPath);
        return CommandStatus.Success;
    }

    public class TreeGoToCommandBuilder : ICommandBuilder
    {
        private IPath? _path;

        public TreeGoToCommandBuilder SetPath(IPath path)
        {
            _path = path;
            return this;
        }

        public ParseCommandStatus Build()
        {
            if (_path is null)
            {
                throw new ArgumentNullException(nameof(_path));
            }

            return new ParseCommandStatus.Success(new TreeGoToCommand(_path));
        }
    }
}