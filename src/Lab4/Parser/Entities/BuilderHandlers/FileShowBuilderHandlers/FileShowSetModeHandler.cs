using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models.FileShowMods;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.FileShowBuilderHandlers;

public class FileShowSetModeHandler : BaseBuilderHandler<FileShowCommand.FileShowCommandBuilder>
{
    public override void Handle(CommandIterator commandIterator, FileShowCommand.FileShowCommandBuilder builder)
    {
        if (commandIterator.Current() == "-m")
        {
            if (commandIterator.MoveNext() && commandIterator.Current() == "console")
            {
                builder.SetMode(new ConsoleFileShowMode());
            }
        }
        else
        {
            Next?.Handle(commandIterator, builder);
        }
    }
}