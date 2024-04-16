using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities;

public class CommandParser : ICommandParser
{
    private readonly ICommandHandler _root;
    public CommandParser(ICommandHandler root)
    {
        _root = root;
    }

    public ParseCommandStatus Parse(string line)
    {
        var commandIterator = new CommandIterator(line);
        return _root.Handle(commandIterator);
    }
}