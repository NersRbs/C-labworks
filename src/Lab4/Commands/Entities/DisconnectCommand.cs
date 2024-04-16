using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class DisconnectCommand : ICommand
{
    private DisconnectCommand() { }

    public static DisconnectCommandBuilder Builder => new DisconnectCommandBuilder();

    public CommandStatus Execute(IContext context)
    {
        context.FileSystem = new NullFileSystem();
        return CommandStatus.Success;
    }

    public class DisconnectCommandBuilder : ICommandBuilder
    {
        public ParseCommandStatus Build()
        {
            return new ParseCommandStatus.Success(new DisconnectCommand());
        }
    }
}