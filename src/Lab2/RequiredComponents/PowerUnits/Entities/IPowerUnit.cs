using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.PowerUnits.Entities;

public interface IPowerUnit : IModel, IPrototype<IPowerUnit>
{
    int PeakLoad { get; }
}