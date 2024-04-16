using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models.ConnectMods;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.ConnectBuilderHandlers;

public class ConnectSetModeHandler : BaseBuilderHandler<ConnectCommand.ConnectCommandBuilder>
{
    public override void Handle(CommandIterator commandIterator, ConnectCommand.ConnectCommandBuilder builder)
    {
        if (commandIterator.Current() == "-m")
        {
            if (commandIterator.MoveNext() && commandIterator.Current() == "local")
            {
                builder.SetMode(ConnectMode.Local);
            }
        }
        else
        {
            Next?.Handle(commandIterator, builder);
        }
    }
}