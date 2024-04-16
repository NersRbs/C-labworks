using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.TreeGoToBuilderHandlers;

public class TreeGoToSetPathHandler : BaseBuilderHandler<TreeGoToCommand.TreeGoToCommandBuilder>
{
    public override void Handle(CommandIterator commandIterator, TreeGoToCommand.TreeGoToCommandBuilder builder)
    {
        if (Directory.Exists(commandIterator.Current()))
        {
            builder.SetPath(new LocalPath(commandIterator.Current()));
        }
        else
        {
            Next?.Handle(commandIterator, builder);
        }
    }
}