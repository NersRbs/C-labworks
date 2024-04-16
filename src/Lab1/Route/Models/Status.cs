using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Fuels.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route.Models;

public abstract record Status
{
    private Status() { }

    public sealed record Success(Time Time, Cost Cost) : Status;

    public sealed record LossOfTheShip : Status;

    public sealed record DestructionOfTheShip : Status;

    public sealed record DeathOfTheCrew : Status;
}