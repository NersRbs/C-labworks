using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models.FileShowMods;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

public interface IFileSystem
{
    TreeListResult TreeList(IPath address, int depth);
    CommandStatus FileShow(IPath address, IPath path, IFileShowMode mode);
    CommandStatus FileMove(IPath address, IPath sourcePath, IPath destinationPath);
    CommandStatus FileCopy(IPath address, IPath sourcePath, IPath destinationPath);
    CommandStatus FileDelete(IPath address, IPath path);
    CommandStatus FileRename(IPath address, IPath path, string name);
}