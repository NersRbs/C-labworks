using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class FileMoveCommand : ICommand
{
    private readonly IPath _sourcePath;
    private readonly IPath _destinationPath;

    private FileMoveCommand(IPath sourcePath, IPath destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public static FileMoveCommandBuilder Builder => new();

    public CommandStatus Execute(IContext context)
    {
        return context.FileSystem.FileMove(context.Address, _sourcePath, _destinationPath);
    }

    public class FileMoveCommandBuilder : ICommandBuilder
    {
        private IPath? _sourcePath;
        private IPath? _destinationPath;

        public FileMoveCommandBuilder SetSourcePath(IPath sourcePath)
        {
            _sourcePath = sourcePath;
            return this;
        }

        public FileMoveCommandBuilder SetDestinationPath(IPath destinationPath)
        {
            _destinationPath = destinationPath;
            return this;
        }

        public ParseCommandStatus Build()
        {
            if (_sourcePath is null)
            {
                return new ParseCommandStatus.InvalidParseCommandArguments("Source path is null");
            }

            if (_destinationPath is null)
            {
                return new ParseCommandStatus.InvalidParseCommandArguments("Destination path is null");
            }

            return new ParseCommandStatus.Success(new FileMoveCommand(_sourcePath, _destinationPath));
        }
    }
}