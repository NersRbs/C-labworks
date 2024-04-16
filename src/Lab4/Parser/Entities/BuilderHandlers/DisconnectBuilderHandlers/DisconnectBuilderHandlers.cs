using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.DisconnectBuilderHandlers;

public class DisconnectBuilderHandlers : BaseBuilderHandler<DisconnectCommand.DisconnectCommandBuilder>
{
    public override void Handle(CommandIterator commandIterator, DisconnectCommand.DisconnectCommandBuilder builder)
    {
        Next?.Handle(commandIterator, builder);
    }
}