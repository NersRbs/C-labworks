using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.HardDrives.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.SsdDrives.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.VideoCards.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.WiFiAdapters.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.CentralProcessingUnits.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.ComputerСases.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.PowerUnits.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.ProcessorCoolingSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Entities;

public interface IComputer : IPrototype<IComputer>
{
    IMotherboard Motherboard { get; }
    ICentralProcessingUnit CentralProcessingUnit { get; }
    IProcessorCoolingSystem ProcessorCoolingSystem { get; }
    IRandomAccessMemory RandomAccessMemory { get; }
    IComputerСase ComputerСase { get; }
    IPowerUnit PowerUnit { get; }
    IVideoCard? VideoCard { get; }
    ISsdDrive? SsdDrive { get; }
    IHardDrive? HardDrive { get; }
    IWiFiAdapter? WiFiAdapter { get; }
}