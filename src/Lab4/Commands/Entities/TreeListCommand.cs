using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class TreeListCommand : ICommand
{
    private readonly int _depth;

    private TreeListCommand(int depth)
    {
        _depth = depth;
    }

    public static TreeListCommandBuilder Builder => new();

    public CommandStatus Execute(IContext context)
    {
          TreeListResult treeListResult = context.FileSystem.TreeList(context.Address, _depth);
          treeListResult.FileSystemObject?.Accept(new TreeVisitor());

          return treeListResult.Status;
    }

    public class TreeListCommandBuilder : ICommandBuilder
    {
        private int _depth = 1;

        public TreeListCommandBuilder SetDepth(int depth)
        {
            _depth = depth < 0 ? 1 : depth;
            return this;
        }

        public ParseCommandStatus Build()
        {
            return new ParseCommandStatus.Success(new TreeListCommand(_depth));
        }
    }
}