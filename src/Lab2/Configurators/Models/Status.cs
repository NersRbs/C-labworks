using Itmo.ObjectOrientedProgramming.Lab2.Computers.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Configurators.Models;

public abstract record Status
{
    private Status() { }
    public sealed record Success(IComputer Computer) : Status;
    public sealed record Warning(string Message, IComputer Computer) : Status;
    public sealed record ImpossibleToBuild(string Message) : Status;
}