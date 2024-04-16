namespace Itmo.ObjectOrientedProgramming.Lab1.Fuels.Entities;

public class GravitonMatter : IFuel
{
    public GravitonMatter(double containedFuel)
    {
        СontainedFuel = containedFuel;
    }

    public double СontainedFuel { get; }
}