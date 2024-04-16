using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.PowerUnits.Entities;

public class PowerUnitBuilder : IPowerUnitBuilder
{
    private string? _model;
    private int? _peakLoad;

    public IPowerUnitBuilder SetModel(string model)
    {
        _model = model;
        return this;
    }

    public IPowerUnitBuilder SetPeakLoad(int peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
    }

    public IPowerUnit Build()
    {
        if (_model is null || _peakLoad is null)
        {
            throw new InvalidOperationException("Not all fields are filled");
        }

        return new PowerUnit(_model, _peakLoad.Value);
    }
}