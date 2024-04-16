using System;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.SsdDrives.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.SsdDrives.Entities;

public class SsdDriveBuilder : ISsdDriveBuilder
{
    private string? _model;
    private ConnectionOption? _connectionOption;
    private int? _capacity;
    private int? _maximumOperatingSpeed;
    private int? _powerConsumption;

    public ISsdDriveBuilder SetModel(string model)
    {
        _model = model;
        return this;
    }

    public ISsdDriveBuilder SetConnectionOption(ConnectionOption connectionOption)
    {
        _connectionOption = connectionOption;
        return this;
    }

    public ISsdDriveBuilder SetCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public ISsdDriveBuilder SetMaximumOperatingSpeed(int maximumOperatingSpeed)
    {
        _maximumOperatingSpeed = maximumOperatingSpeed;
        return this;
    }

    public ISsdDriveBuilder SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ISsdDrive Build()
    {
        if (_model is null ||
            _connectionOption is null ||
            _capacity is null ||
            _maximumOperatingSpeed is null ||
            _powerConsumption is null)
        {
            throw new InvalidOperationException("Not all fields are filled");
        }

        return new SsdDrive(
            _model,
            _connectionOption.Value,
            _capacity.Value,
            _maximumOperatingSpeed.Value,
            _powerConsumption.Value);
    }
}