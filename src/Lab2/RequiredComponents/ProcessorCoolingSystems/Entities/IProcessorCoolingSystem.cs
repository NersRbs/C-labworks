using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.ProcessorCoolingSystems.Entities;

public interface IProcessorCoolingSystem : IModel, IPrototype<IProcessorCoolingSystem>
{
    double Dimensions { get; }
    HashSet<Socket> SupportedSockets { get; }
    int MaximumDissipatedHeatMass { get; }
}