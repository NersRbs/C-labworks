using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.FileMoveBuilderHandlers;

public class FileMoveSetPathsHandler : BaseBuilderHandler<FileMoveCommand.FileMoveCommandBuilder>
{
    public override void Handle(CommandIterator commandIterator, FileMoveCommand.FileMoveCommandBuilder builder)
    {
        string sourcePath = commandIterator.Current();
        if (commandIterator.MoveNext())
        {
            string destinationPath = commandIterator.Current();
            builder.SetSourcePath(new LocalPath(sourcePath));
            builder.SetDestinationPath(new LocalPath(destinationPath));
        }
        else
        {
            Next?.Handle(commandIterator, builder);
        }
    }
}