using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.ConnectBuilderHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.DisconnectBuilderHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.FileCopyBuilderHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.FileDeleteBuilderHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.FileMoveBuilderHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.FileRenameBuilderHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.FileShowBuilderHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.TreeGoToBuilderHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers.TreeListBuilderHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Test
{
    [Fact]
    public void Disconnect_ShouldReturnSuccess()
    {
        // Arrange
        var createCommandHandler =
            new CommandHandler<DisconnectCommand.DisconnectCommandBuilder>("disconnect",
                new DisconnectBuilderHandlers());
        var parser = new CommandParser(createCommandHandler);

        // Act
        ParseCommandStatus status = parser.Parse("disconnect");

        // Assert
        Assert.True(status is ParseCommandStatus.Success);
    }

    [Fact]
    public void TreeGoToRoot_ShouldReturnSuccess()
    {
        // Arrange
        var treeGoToSetPathHandler = new TreeGoToSetPathHandler();
        var createCommandHandler =
            new CommandHandler<TreeGoToCommand.TreeGoToCommandBuilder>("tree goto", treeGoToSetPathHandler);
        var parser = new CommandParser(createCommandHandler);

        // Act
        ParseCommandStatus status = parser.Parse("tree goto C:\\Test");

        // Assert
        Assert.True(status is ParseCommandStatus.Success);
    }

    [Fact]
    public void TreeList_ShouldReturnSuccess()
    {
        // Arrange
        var treeListSetDepthHandler = new TreeListSetDepthHandler();
        var createCommandHandler =
            new CommandHandler<TreeListCommand.TreeListCommandBuilder>("show", treeListSetDepthHandler);
        var parser = new CommandParser(createCommandHandler);

        // Act
        ParseCommandStatus status = parser.Parse("show -d 10 -m console");

        // Assert
        Assert.True(status is ParseCommandStatus.Success);
    }

    [Fact]
    public void FileShow_ShouldReturnSuccess()
    {
        // Arrange
        var fileShowSetPathHandler = new FileShowSetPathHandler();
        var fileShowSetModHandler = new FileShowSetModeHandler();
        fileShowSetModHandler.AddNext(fileShowSetPathHandler);
        var createCommandHandler =
            new CommandHandler<FileShowCommand.FileShowCommandBuilder>("file show", fileShowSetModHandler);
        var parser = new CommandParser(createCommandHandler);

        // Act
        ParseCommandStatus status = parser.Parse("file show C:\\Test -m console");

        // Assert
        Assert.True(status is ParseCommandStatus.Success);
    }

    [Fact]
    public void FileMove_ShouldReturnSuccess()
    {
        // Arrange
        var fileMoveSetPathsHandler = new FileMoveSetPathsHandler();
        var createCommandHandler =
            new CommandHandler<FileMoveCommand.FileMoveCommandBuilder>("file move", fileMoveSetPathsHandler);
        var parser = new CommandParser(createCommandHandler);

        // Act
        ParseCommandStatus status = parser.Parse("file move C:\\Test C:\\Test2");

        // Assert
        Assert.True(status is ParseCommandStatus.Success);
    }

    [Fact]
    public void FileCopy_ShouldReturnSuccess()
    {
        // Arrange
        var fileCopySetPathsHandler = new FileCopySetPathsHandler();
        var createCommandHandler =
            new CommandHandler<FileCopyCommand.FileCopyCommandBuilder>("file copy", fileCopySetPathsHandler);
        var parser = new CommandParser(createCommandHandler);

        // Act
        ParseCommandStatus status = parser.Parse("file copy C:\\Test C:\\Test2");

        // Assert
        Assert.True(status is ParseCommandStatus.Success);
    }

    [Fact]
    public void FileDelete_ShouldReturnSuccess()
    {
        // Arrange
        var fileDeleteSetPathHandler = new FileDeleteSetPathHandler();
        var createCommandHandler =
            new CommandHandler<FileDeleteCommand.FileDeleteCommandBuilder>("file delete", fileDeleteSetPathHandler);
        var parser = new CommandParser(createCommandHandler);

        // Act
        ParseCommandStatus status = parser.Parse("file delete C:\\Test");

        // Assert
        Assert.True(status is ParseCommandStatus.Success);
    }

    [Fact]
    public void FileRename_ShouldReturnSuccess()
    {
        // Arrange
        var fileRenameSetPathHandler = new FileRenameSetPathAndNameHandler();
        var createCommandHandler =
            new CommandHandler<FileRenameCommand.FileRenameCommandBuilder>("file rename", fileRenameSetPathHandler);
        var parser = new CommandParser(createCommandHandler);

        // Act
        ParseCommandStatus status = parser.Parse("file rename C:\\Test C:\\Test2");

        // Assert
        Assert.True(status is ParseCommandStatus.Success);
    }
}