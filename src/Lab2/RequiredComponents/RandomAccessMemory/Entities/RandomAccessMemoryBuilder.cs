using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Entities;

public class RandomAccessMemoryBuilder : IRandomAccessMemoryBuilder
{
    private string? _model;
    private int? _countOfAvailableMemorySize;
    private bool? _supportedJedecAndVoltageFrequencyPairs;
    private HashSet<XmpProfile>? _availableXmpOrDocpProfiles;
    private FormFactor? _formFactor;
    private Version? _ddrStandardVersion;
    private int? _powerConsumption;

    public IRandomAccessMemoryBuilder SetModel(string model)
    {
        _model = model;
        return this;
    }

    public IRandomAccessMemoryBuilder SetCountOfAvailableMemorySize(int countOfAvailableMemorySize)
    {
        _countOfAvailableMemorySize = countOfAvailableMemorySize;
        return this;
    }

    public IRandomAccessMemoryBuilder SetSupportedJedecAndVoltageFrequencyPairs(
        bool supportedJedecAndVoltageFrequencyPairs)
    {
        _supportedJedecAndVoltageFrequencyPairs = supportedJedecAndVoltageFrequencyPairs;
        return this;
    }

    public IRandomAccessMemoryBuilder SetAvailableXmpOrDocpProfiles(HashSet<XmpProfile> availableXmpOrDocpProfiles)
    {
        _availableXmpOrDocpProfiles = availableXmpOrDocpProfiles;
        return this;
    }

    public IRandomAccessMemoryBuilder SetFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRandomAccessMemoryBuilder SetDdrStandardVersion(Version ddrStandardVersion)
    {
        _ddrStandardVersion = ddrStandardVersion;
        return this;
    }

    public IRandomAccessMemoryBuilder SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IRandomAccessMemory Build()
    {
        if (_model is null ||
            _countOfAvailableMemorySize is null ||
            _supportedJedecAndVoltageFrequencyPairs is null ||
            _availableXmpOrDocpProfiles is null ||
            _formFactor is null ||
            _ddrStandardVersion is null ||
            _powerConsumption is null)
        {
            throw new InvalidOperationException("Not all fields are filled");
        }

        return new RandomAccessMemory(
            _model,
            _countOfAvailableMemorySize.Value,
            _supportedJedecAndVoltageFrequencyPairs.Value,
            _availableXmpOrDocpProfiles,
            _formFactor.Value,
            _ddrStandardVersion,
            _powerConsumption.Value);
    }
}