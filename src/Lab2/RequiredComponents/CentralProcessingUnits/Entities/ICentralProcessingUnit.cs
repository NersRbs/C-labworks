using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.CentralProcessingUnits.Entities;

public interface ICentralProcessingUnit : IModel, IPrototype<ICentralProcessingUnit>
{
    double CoreFrequency { get; }
    int CountOfCores { get; }
    Socket Socket { get; }
    bool PresenceBuiltInVideoCore { get; }
    HashSet<double> SupportedMemoryFrequencies { get; }
    int HeatDissipation { get; }
    int PowerConsumption { get; }
}