using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class FileDeleteCommand : ICommand
{
    private readonly IPath _path;

    private FileDeleteCommand(IPath path)
    {
        _path = path;
    }

    public static FileDeleteCommandBuilder Builder => new();
    public CommandStatus Execute(IContext context)
    {
        return context.FileSystem.FileDelete(context.Address, _path);
    }

    public class FileDeleteCommandBuilder : ICommandBuilder
    {
        private IPath? _path;

        public FileDeleteCommandBuilder SetPath(IPath path)
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

            return new ParseCommandStatus.Success(new FileDeleteCommand(_path));
        }
    }
}