using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

public readonly record struct Message(string Header, string Body, ImportanceLevel ImportanceLevel)
{
    public override string ToString()
    {
        return ImportanceLevel + ":/n" + Body;
    }
}