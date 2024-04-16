using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.ProcessorCoolingSystems.Entities;

public class ProcessorCoolingSystem : IProcessorCoolingSystem
{
    public ProcessorCoolingSystem(
        string model,
        double dimensions,
        HashSet<Socket> supportedSockets,
        int maximumDissipatedHeatMass)
    {
        if (dimensions <= 0)
        {
            throw new ArgumentException("Dimensions must be positive", nameof(dimensions));
        }

        if (maximumDissipatedHeatMass < 0)
        {
            throw new ArgumentException(
                "Maximum dissipated heat mass must be non-negative",
                nameof(maximumDissipatedHeatMass));
        }

        Model = model;
        Dimensions = dimensions;
        SupportedSockets = supportedSockets;
        MaximumDissipatedHeatMass = maximumDissipatedHeatMass;
    }

    public string Model { get; }

    public double Dimensions { get; }

    public HashSet<Socket> SupportedSockets { get; }

    public int MaximumDissipatedHeatMass { get; }

    public IProcessorCoolingSystem Clone()
    {
        return new ProcessorCoolingSystem(
            Model,
            Dimensions,
            SupportedSockets,
            MaximumDissipatedHeatMass);
    }
}