using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemObjects.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

public record TreeListResult(CommandStatus Status, IFileSystemComponent? FileSystemObject);