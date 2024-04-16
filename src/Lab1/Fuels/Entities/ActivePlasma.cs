namespace Itmo.ObjectOrientedProgramming.Lab1.Fuels.Entities;

public class ActivePlasma : IFuel
{
    public ActivePlasma(double containedFuel)
    {
        СontainedFuel = containedFuel;
    }

    public double СontainedFuel { get; }
}