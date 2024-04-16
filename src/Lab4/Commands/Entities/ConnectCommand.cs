using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models.ConnectMods;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class ConnectCommand : ICommand
{
    private readonly IPath _path;
    private readonly ConnectMode _mode;

    private ConnectCommand(IPath path, ConnectMode mode)
    {
        _path = path;
        _mode = mode;
    }

    public static ConnectCommandBuilder Builder => new();

    public CommandStatus Execute(IContext context)
    {
        switch (_mode)
        {
            case ConnectMode.Local:
                context.FileSystem = new LocalFileSystem();
                break;
            default:
                return CommandStatus.InvalidArgument;
        }

        if (!Directory.Exists(_path.GetPath()) && !File.Exists(_path.GetPath()))
        {
            return CommandStatus.DirectoryNotFound;
        }

        context.Address = _path;
        return CommandStatus.Success;
    }

    public class ConnectCommandBuilder : ICommandBuilder
    {
        private IPath? _path;
        private ConnectMode? _mode;

        public ConnectCommandBuilder SetPath(IPath path)
        {
            _path = path;
            return this;
        }

        public ConnectCommandBuilder SetMode(ConnectMode mode)
        {
            _mode = mode;
            return this;
        }

        public ParseCommandStatus Build()
        {
            if (_path is null)
            {
                return new ParseCommandStatus.InvalidParseCommandArguments("Path is null");
            }

            if (_mode is null)
            {
                return new ParseCommandStatus.InvalidParseCommandArguments("Mode is null");
            }

            return new ParseCommandStatus.Success(new ConnectCommand(_path, _mode.GetValueOrDefault()));
        }
    }
}