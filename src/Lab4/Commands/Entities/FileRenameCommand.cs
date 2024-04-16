using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class FileRenameCommand : ICommand
{
    private readonly IPath _path;
    private readonly string _name;

    private FileRenameCommand(IPath path, string name)
    {
        _path = path;
        _name = name;
    }

    public static FileRenameCommandBuilder Builder => new();
    public CommandStatus Execute(IContext context)
    {
        return context.FileSystem.FileRename(context.Address, _path, _name);
    }

    public class FileRenameCommandBuilder : ICommandBuilder
    {
        private IPath? _path;
        private string? _name;

        public FileRenameCommandBuilder SetPath(IPath path)
        {
            _path = path;
            return this;
        }

        public FileRenameCommandBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ParseCommandStatus Build()
        {
            if (_path is null)
            {
                throw new ArgumentNullException(nameof(_path));
            }

            if (_name is null)
            {
                throw new ArgumentNullException(nameof(_name));
            }

            return new ParseCommandStatus.Success(new FileRenameCommand(_path, _name));
        }
    }
}