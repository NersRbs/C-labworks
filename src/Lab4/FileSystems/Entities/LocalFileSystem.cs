using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemObjects.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models.FileShowMods;
using Directory = System.IO.Directory;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

public class LocalFileSystem : IFileSystem
{
    public TreeListResult TreeList(IPath address, int depth)
    {
        string name = Path.GetFileName(address.GetPath());
        var root = new DirectoryComponent(name);
        CreateTree(address.GetPath(), root, depth, depth);

        return new TreeListResult(CommandStatus.Success, root);
    }

    public CommandStatus FileShow(IPath address, IPath path, IFileShowMode mode)
    {
        string fullPath = GetFullPath(address, path);
        if (!File.Exists(fullPath))
        {
            return CommandStatus.FileNotFound;
        }

        string content = File.ReadAllText(fullPath);
        mode.Show(content);

        return CommandStatus.Success;
    }

    public CommandStatus FileMove(IPath address, IPath sourcePath, IPath destinationPath)
    {
        string sourceFullPath = GetFullPath(address, sourcePath);
        string destinationFullPath = GetFullPath(address, destinationPath);

        if (!File.Exists(sourceFullPath))
        {
            return CommandStatus.FileNotFound;
        }

        if (!Directory.Exists(destinationFullPath))
        {
            return CommandStatus.DirectoryNotFound;
        }

        string destinationFilePath = Path.Combine(destinationFullPath, Path.GetFileName(sourceFullPath));
        File.Move(sourceFullPath, destinationFilePath);

        return CommandStatus.Success;
    }

    public CommandStatus FileCopy(IPath address, IPath sourcePath, IPath destinationPath)
    {
        string sourceFullPath = GetFullPath(address, sourcePath);
        string destinationFullPath = GetFullPath(address, destinationPath);

        if (!File.Exists(sourceFullPath))
        {
            return CommandStatus.FileNotFound;
        }

        if (!Directory.Exists(destinationFullPath))
        {
            return CommandStatus.DirectoryNotFound;
        }

        string destinationFilePath = Path.Combine(destinationFullPath, Path.GetFileName(sourceFullPath));
        File.Copy(sourceFullPath, destinationFilePath);

        return CommandStatus.Success;
    }

    public CommandStatus FileDelete(IPath address, IPath path)
    {
        string fullPath = GetFullPath(address, path);
        if (!File.Exists(fullPath))
        {
            return CommandStatus.FileNotFound;
        }

        File.Delete(fullPath);

        return CommandStatus.Success;
    }

    public CommandStatus FileRename(IPath address, IPath path, string name)
    {
        string fullPath = GetFullPath(address, path);
        if (!File.Exists(fullPath))
        {
            return CommandStatus.FileNotFound;
        }

        string? directory = Path.GetDirectoryName(fullPath);
        if (!Directory.Exists(directory))
        {
            return CommandStatus.DirectoryNotFound;
        }

        string newPath = Path.Combine(directory, name);
        File.Move(fullPath, newPath);

        return CommandStatus.Success;
    }

    private static void CreateTree(string path, DirectoryComponent directory, int depth, int maxDepth)
    {
        if (depth < 0 || depth > maxDepth)
        {
            return;
        }

        string[] files = Directory.GetFiles(path);
        string[] directories = Directory.GetDirectories(path);

        foreach (string file in files)
        {
            directory.Add(new FileComponent(Path.GetFileName(file)));
        }

        foreach (string directoryPath in directories)
        {
            var newDirectory = new DirectoryComponent(Path.GetFileName(directoryPath));
            directory.Add(newDirectory);
            CreateTree(directoryPath, newDirectory, depth - 1, maxDepth);
        }
    }

    private static string GetFullPath(IPath address, IPath path)
    {
        bool isAbsolutePath = Path.IsPathRooted(path.GetPath());
        string fullPath = isAbsolutePath ? path.GetPath() : Path.GetFullPath(Path.Combine(address.GetPath(), path.GetPath()));

        return Path.GetFullPath(fullPath);
    }
}