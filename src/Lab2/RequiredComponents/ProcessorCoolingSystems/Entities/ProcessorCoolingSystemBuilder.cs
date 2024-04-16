using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.ProcessorCoolingSystems.Entities;

public class ProcessorCoolingSystemBuilder : IProcessorCoolingSystemBuilder
{
    private string? _model;
    private double? _dimensions;
    private HashSet<Socket>? _supportedSockets;
    private int? _maximumDissipatedHeatMass;

    public IProcessorCoolingSystemBuilder SetModel(string model)
    {
        _model = model;
        return this;
    }

    public IProcessorCoolingSystemBuilder SetDimensions(double dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public IProcessorCoolingSystemBuilder SetSupportedSockets(HashSet<Socket> supportedSockets)
    {
        _supportedSockets = supportedSockets;
        return this;
    }

    public IProcessorCoolingSystemBuilder SetMaximumDissipatedHeatMass(int maximumDissipatedHeatMass)
    {
        _maximumDissipatedHeatMass = maximumDissipatedHeatMass;
        return this;
    }

    public IProcessorCoolingSystem Build()
    {
        if (_model is null ||
            _dimensions is null ||
            _supportedSockets is null ||
            _maximumDissipatedHeatMass is null)
        {
            throw new InvalidOperationException("Not all fields are filled");
        }

        return new ProcessorCoolingSystem(
            _model,
            _dimensions.Value,
            _supportedSockets,
            _maximumDissipatedHeatMass.Value);
    }
}