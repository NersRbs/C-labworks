namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers;

public interface IBuilderHandler<T>
{
    void AddNext(IBuilderHandler<T> handler);
    void Handle(CommandIterator commandIterator, T builder);
}