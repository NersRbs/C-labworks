using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models.FileShowMods;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class FileShowCommand : ICommand
{
    private readonly IPath _path;
    private readonly IFileShowMode _mode;

    private FileShowCommand(IPath path, IFileShowMode mode)
    {
        _path = path;
        _mode = mode;
    }

    public static FileShowCommandBuilder Builder => new();

    public CommandStatus Execute(IContext context)
    {
        return context.FileSystem.FileShow(context.Address, _path, _mode);
    }

    public class FileShowCommandBuilder : ICommandBuilder
    {
        private IPath? _path;
        private IFileShowMode? _mode;

        public FileShowCommandBuilder SetPath(IPath path)
        {
            _path = path;
            return this;
        }

        public FileShowCommandBuilder SetMode(IFileShowMode mode)
        {
            _mode = mode;
            return this;
        }

        public ParseCommandStatus Build()
        {
            if (_path is null)
            {
                throw new ArgumentNullException(nameof(_path));
            }

            if (_mode is null)
            {
                throw new ArgumentNullException(nameof(_mode));
            }

            return new ParseCommandStatus.Success(new FileShowCommand(_path, _mode));
        }
    }
}