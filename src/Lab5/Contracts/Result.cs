namespace Contracts;

public abstract record Result
{
    private Result() { }

    public sealed record Success : Result;

    public sealed record Failed : Result;
}