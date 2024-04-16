namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.PowerUnits.Entities;

public interface IPowerUnitBuilder
{
    IPowerUnitBuilder SetModel(string model);
    IPowerUnitBuilder SetPeakLoad(int peakLoad);
    IPowerUnit Build();
}