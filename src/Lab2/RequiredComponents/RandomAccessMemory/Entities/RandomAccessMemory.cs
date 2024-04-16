using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Entities;

public class RandomAccessMemory : IRandomAccessMemory
{
    public RandomAccessMemory(
        string model,
        int countOfAvailableMemorySize,
        bool supportedJedecAndVoltageFrequencyPairs,
        HashSet<XmpProfile> availableXmpOrDocpProfiles,
        FormFactor formFactor,
        Version ddrStandardVersion,
        int powerConsumption)
    {
        if (countOfAvailableMemorySize < 0)
        {
            throw new ArgumentException(
                "Count of available memory size must be positive",
                nameof(countOfAvailableMemorySize));
        }

        if (powerConsumption < 0)
        {
            throw new ArgumentException(
                "Power consumption must be non-negative",
                nameof(powerConsumption));
        }

        Model = model;
        CountOfAvailableMemorySize = countOfAvailableMemorySize;
        SupportedJedecAndVoltageFrequencyPairs = supportedJedecAndVoltageFrequencyPairs;
        AvailableXmpOrDocpProfiles = availableXmpOrDocpProfiles;
        FormFactor = formFactor;
        DdrStandardVersion = ddrStandardVersion;
        PowerConsumption = powerConsumption;
    }

    public string Model { get; }

    public int CountOfAvailableMemorySize { get; }

    public bool SupportedJedecAndVoltageFrequencyPairs { get; }

    public HashSet<XmpProfile> AvailableXmpOrDocpProfiles { get; }

    public FormFactor FormFactor { get; }

    public Version DdrStandardVersion { get; }

    public int PowerConsumption { get; }

    public IRandomAccessMemory Clone()
    {
        return new RandomAccessMemory(
            Model,
            CountOfAvailableMemorySize,
            SupportedJedecAndVoltageFrequencyPairs,
            AvailableXmpOrDocpProfiles,
            FormFactor,
            DdrStandardVersion,
            PowerConsumption);
    }
}