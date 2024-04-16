using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Entities;

public interface IRandomAccessMemoryBuilder
{
    IRandomAccessMemoryBuilder SetModel(string model);
    IRandomAccessMemoryBuilder SetCountOfAvailableMemorySize(int countOfAvailableMemorySize);
    IRandomAccessMemoryBuilder SetSupportedJedecAndVoltageFrequencyPairs(bool supportedJedecAndVoltageFrequencyPairs);
    IRandomAccessMemoryBuilder SetAvailableXmpOrDocpProfiles(HashSet<XmpProfile> availableXmpOrDocpProfiles);
    IRandomAccessMemoryBuilder SetFormFactor(FormFactor formFactor);
    IRandomAccessMemoryBuilder SetDdrStandardVersion(Version ddrStandardVersion);
    IRandomAccessMemoryBuilder SetPowerConsumption(int powerConsumption);
    IRandomAccessMemory Build();
}