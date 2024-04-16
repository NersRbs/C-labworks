namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public abstract record ImportanceLevel(int Level)
{
    public sealed record Low() : ImportanceLevel(10);
    public sealed record Medium() : ImportanceLevel(50);
    public sealed record High() : ImportanceLevel(90);
}