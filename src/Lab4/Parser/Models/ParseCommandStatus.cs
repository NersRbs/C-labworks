using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

public abstract record ParseCommandStatus
{
    public sealed record Success(ICommand Command) : ParseCommandStatus;
    public sealed record CanNotProcess : ParseCommandStatus;

    public sealed record InvalidParseCommandArguments(string Message) : ParseCommandStatus;
}