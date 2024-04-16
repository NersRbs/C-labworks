using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Entities;

public interface IRandomAccessMemory : IModel, IPrototype<IRandomAccessMemory>
{
    int CountOfAvailableMemorySize { get; }
    bool SupportedJedecAndVoltageFrequencyPairs { get; }
    HashSet<XmpProfile> AvailableXmpOrDocpProfiles { get; }
    FormFactor FormFactor { get; }
    Version DdrStandardVersion { get; }
    int PowerConsumption { get; }
}