using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.PowerUnits.Entities;

public class PowerUnit : IPowerUnit
{
    public PowerUnit(string model, int peakLoad)
    {
        if (peakLoad <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(peakLoad), "Peak load must be positive");
        }

        Model = model;
        PeakLoad = peakLoad;
    }

    public string Model { get; }

    public int PeakLoad { get; }

    public IPowerUnit Clone()
    {
        return new PowerUnit(Model, PeakLoad);
    }
}