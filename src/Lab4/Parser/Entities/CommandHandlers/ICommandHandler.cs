using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.CommandHandlers;

public interface ICommandHandler
{
    void AddNext(ICommandHandler handler);
    ParseCommandStatus Handle(CommandIterator commandIterator);
}