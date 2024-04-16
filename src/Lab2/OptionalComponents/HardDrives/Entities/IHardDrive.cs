using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.HardDrives.Entities;

public interface IHardDrive : IModel, IPrototype<IHardDrive>
{
    int Capacity { get; }
    int SpindleRotationSpeed { get; }
    int PowerConsumption { get; }
}