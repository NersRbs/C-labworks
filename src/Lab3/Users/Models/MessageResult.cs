namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

public abstract record MessageResult
{
    private MessageResult() { }
    public sealed record Success : MessageResult;
    public sealed record MessageAlreadyRead : MessageResult;
}