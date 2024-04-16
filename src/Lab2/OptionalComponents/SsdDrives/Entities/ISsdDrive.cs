using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.SsdDrives.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.SsdDrives.Entities;

public interface ISsdDrive : IModel, IPrototype<ISsdDrive>
{
    ConnectionOption ConnectionOption { get; }
    int Capacity { get; }
    int MaximumOperatingSpeed { get; }
    int PowerConsumption { get; }
}