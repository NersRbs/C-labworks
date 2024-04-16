using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models.FileShowMods;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

public class NullFileSystem : IFileSystem
{
    public TreeListResult TreeList(IPath address, int depth)
    {
        return new TreeListResult(CommandStatus.NotConnected, null);
    }

    public CommandStatus FileShow(IPath address, IPath path, IFileShowMode mode)
    {
        return CommandStatus.NotConnected;
    }

    public CommandStatus FileMove(IPath address, IPath sourcePath, IPath destinationPath)
    {
        return CommandStatus.NotConnected;
    }

    public CommandStatus FileCopy(IPath address, IPath sourcePath, IPath destinationPath)
    {
        return CommandStatus.NotConnected;
    }

    public CommandStatus FileDelete(IPath address, IPath path)
    {
        return CommandStatus.NotConnected;
    }

    public CommandStatus FileRename(IPath address, IPath path, string name)
    {
        return CommandStatus.NotConnected;
    }
}