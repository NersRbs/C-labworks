using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.CommandHandlers;

public class CommandHandler<T> : ICommandHandler
    where T : ICommandBuilder, new()
{
    private readonly string _command;
    private readonly int _length;
    private readonly IBuilderHandler<T> _builderHandler;
    private ICommandHandler? _next;

    public CommandHandler(string command, IBuilderHandler<T> builderHandler)
    {
        _command = command;
        _length = command.Split(' ').Length;
        _builderHandler = builderHandler;
    }

    public void AddNext(ICommandHandler handler)
    {
        if (_next == null)
        {
            _next = handler;
        }
        else
        {
            _next.AddNext(handler);
        }
    }

    public ParseCommandStatus Handle(CommandIterator commandIterator)
    {
        var builder = new T();
        if (_command != commandIterator.Current(_length))
            return _next?.Handle(commandIterator) ?? new ParseCommandStatus.CanNotProcess();

        while (commandIterator.MoveNext())
        {
            _builderHandler.Handle(commandIterator, builder);
        }

        return builder.Build();
    }
}