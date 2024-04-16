using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.HardDrives.Entities;

public class HardDriveBuilder : IHardDriveBuilder
{
    private string? _model;
    private int? _capacity;
    private int? _spindleRotationSpeed;
    private int? _powerConsumption;

    public IHardDriveBuilder SetModel(string model)
    {
        _model = model;
        return this;
    }

    public IHardDriveBuilder SetCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IHardDriveBuilder SetSpindleRotationSpeed(int spindleRotationSpeed)
    {
        _spindleRotationSpeed = spindleRotationSpeed;
        return this;
    }

    public IHardDriveBuilder SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IHardDrive Build()
    {
        if (_model is null ||
            _capacity is null ||
            _spindleRotationSpeed is null ||
            _powerConsumption is null)
        {
            throw new InvalidOperationException("Not all fields are filled");
        }

        return new HardDrive(
            _model,
            _capacity.Value,
            _spindleRotationSpeed.Value,
            _powerConsumption.Value);
    }
}