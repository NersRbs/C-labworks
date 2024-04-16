using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.Chipset;

public interface IChipset : IModel, IPrototype<IChipset>
{
    uint Frequency { get; }
    XmpProfile XmpSupport { get; }
}