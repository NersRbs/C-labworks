using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.Chipset;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Entities;

public interface IMotherboard : IModel, IPrototype<IMotherboard>
{
    Socket Socket { get; }
    int CountOfLinesSolderedPciE { get; }
    int CountOfPortsSolderedSata { get; }
    IChipset Chipset { get; }
    Ddr SupportedDdrStandard { get; }
    int CountOfTablesUnderRam { get; }
    FormFactor FormFactor { get; }
    IBios Bios { get; }
}