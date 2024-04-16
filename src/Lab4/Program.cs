using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.ConnectBuilderHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.TreeListBuilderHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var connectSetModeHandler = new ConnectSetModeHandler();
        var connectSetPathHandler = new ConnectSetPathHandler();
        connectSetModeHandler.AddNext(connectSetPathHandler);
        var iterator = new CommandIterator("connect C:\\Test -m local");

        var createCommandHandler = new CommandHandler<ConnectCommand.ConnectCommandBuilder>("connect", connectSetModeHandler);
        ICommand? command = (createCommandHandler.Handle(iterator) as ParseCommandStatus.Success)?.Command;

        var context = new Context();
        command?.Execute(context);

        iterator = new CommandIterator("show -d 10 -m console");
        var treeListSetDepthHandler = new TreeListSetDepthHandler();
        var commandHandler = new CommandHandler<TreeListCommand.TreeListCommandBuilder>("show", treeListSetDepthHandler);
        command = (commandHandler.Handle(iterator) as ParseCommandStatus.Success)?.Command;
        command?.Execute(context);
    }
}