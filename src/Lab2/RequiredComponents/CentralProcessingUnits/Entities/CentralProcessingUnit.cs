using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.CentralProcessingUnits.Entities;

public class CentralProcessingUnit : ICentralProcessingUnit
{
    public CentralProcessingUnit(
        string model,
        double coreFrequency,
        int countOfCores,
        Socket socket,
        bool presenceBuiltInVideoCore,
        HashSet<double> supportedMemoryFrequencies,
        int heatDissipation,
        int powerConsumption)
    {
        if (coreFrequency <= 0)
        {
            throw new ArgumentException("Core frequency must be positive", nameof(coreFrequency));
        }

        if (countOfCores < 0)
        {
            throw new ArgumentException("Count of cores must be non-negative", nameof(countOfCores));
        }

        if (heatDissipation < 0)
        {
            throw new ArgumentException("Heat dissipation must be non-negative", nameof(heatDissipation));
        }

        if (powerConsumption < 0)
        {
            throw new ArgumentException("Power consumption must be non-negative", nameof(powerConsumption));
        }

        Model = model;
        CoreFrequency = coreFrequency;
        CountOfCores = countOfCores;
        Socket = socket;
        PresenceBuiltInVideoCore = presenceBuiltInVideoCore;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        HeatDissipation = heatDissipation;
        PowerConsumption = powerConsumption;
    }

    public string Model { get; }

    public double CoreFrequency { get; }

    public int CountOfCores { get; }

    public Socket Socket { get; }

    public bool PresenceBuiltInVideoCore { get; }

    public HashSet<double> SupportedMemoryFrequencies { get; }

    public int HeatDissipation { get; }

    public int PowerConsumption { get; }

    public ICentralProcessingUnit Clone()
    {
        return new CentralProcessingUnit(
            Model,
            CoreFrequency,
            CountOfCores,
            Socket,
            PresenceBuiltInVideoCore,
            SupportedMemoryFrequencies,
            HeatDissipation,
            PowerConsumption);
    }
}