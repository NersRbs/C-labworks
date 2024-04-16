using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.TreeListBuilderHandlers;

public class TreeListSetDepthHandler : BaseBuilderHandler<TreeListCommand.TreeListCommandBuilder>
{
    public override void Handle(CommandIterator commandIterator, TreeListCommand.TreeListCommandBuilder builder)
    {
        if (commandIterator.Current() == "-d")
        {
            if (commandIterator.MoveNext() && int.TryParse(commandIterator.Current(), out int depth))
            {
                builder.SetDepth(depth);
            }
        }
        else
        {
            Next?.Handle(commandIterator, builder);
        }
    }
}