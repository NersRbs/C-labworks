namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.BuilderHandlers;

public abstract class BaseBuilderHandler<T> : IBuilderHandler<T>
{
    protected IBuilderHandler<T>? Next { get; private set; }
    public void AddNext(IBuilderHandler<T> handler)
    {
        if (Next == null)
        {
            Next = handler;
        }
        else
        {
            Next.AddNext(handler);
        }
    }

    public abstract void Handle(CommandIterator commandIterator, T builder);
}