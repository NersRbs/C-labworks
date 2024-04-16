using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.FileRenameBuilderHandlers;

public class FileRenameSetPathAndNameHandler : BaseBuilderHandler<FileRenameCommand.FileRenameCommandBuilder>
{
    public override void Handle(CommandIterator commandIterator, FileRenameCommand.FileRenameCommandBuilder builder)
    {
        string path = commandIterator.Current();
        if (commandIterator.MoveNext())
        {
            string name = commandIterator.Current();
            builder.SetPath(new LocalPath(path));
            builder.SetName(name);
        }
        else
        {
            Next?.Handle(commandIterator, builder);
        }
    }
}