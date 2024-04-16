using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.CentralProcessingUnits.Entities;

public class CentralProcessingUnitBuilder : ICentralProcessingUnitBuilder
{
    private string? _model;
    private double? _coreFrequency;
    private int? _countOfCores;
    private Socket? _socket;
    private bool? _presenceBuiltInVideoCore;
    private HashSet<double>? _supportedMemoryFrequencies;
    private int? _heatDissipation;
    private int? _powerConsumption;

    public ICentralProcessingUnitBuilder SetModel(string model)
    {
        _model = model;
        return this;
    }

    public ICentralProcessingUnitBuilder SetCoreFrequency(double coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public ICentralProcessingUnitBuilder SetCountOfCores(int countOfCores)
    {
        _countOfCores = countOfCores;
        return this;
    }

    public ICentralProcessingUnitBuilder SetSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public ICentralProcessingUnitBuilder SetPresenceBuiltInVideoCore(bool presenceBuiltInVideoCore)
    {
        _presenceBuiltInVideoCore = presenceBuiltInVideoCore;
        return this;
    }

    public ICentralProcessingUnitBuilder SetSupportedMemoryFrequencies(HashSet<double> supportedMemoryFrequencies)
    {
        _supportedMemoryFrequencies = supportedMemoryFrequencies;
        return this;
    }

    public ICentralProcessingUnitBuilder SetHeatDissipation(int heatDissipation)
    {
        _heatDissipation = heatDissipation;
        return this;
    }

    public ICentralProcessingUnitBuilder SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ICentralProcessingUnit Build()
    {
        if (_model is null ||
            _coreFrequency is null ||
            _countOfCores is null ||
            _socket is null ||
            _presenceBuiltInVideoCore is null ||
            _supportedMemoryFrequencies is null ||
            _heatDissipation is null ||
            _powerConsumption is null)
        {
            throw new InvalidOperationException("Not all fields are filled");
        }

        return new CentralProcessingUnit(
            _model,
            _coreFrequency.Value,
            _countOfCores.Value,
            _socket.Value,
            _presenceBuiltInVideoCore.Value,
            _supportedMemoryFrequencies,
            _heatDissipation.Value,
            _powerConsumption.Value);
    }
}