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

public class Computer : IComputer
{
    public Computer(
        IMotherboard motherboard,
        ICentralProcessingUnit centralProcessingUnit,
        IProcessorCoolingSystem processorCoolingSystem,
        IRandomAccessMemory randomAccessMemory,
        IComputerСase computerСase,
        IPowerUnit powerUnit,
        IVideoCard? videoCard,
        ISsdDrive? ssdDrive,
        IHardDrive? hardDrive,
        IWiFiAdapter? wiFiAdapter)
    {
        Motherboard = motherboard;
        CentralProcessingUnit = centralProcessingUnit;
        ProcessorCoolingSystem = processorCoolingSystem;
        RandomAccessMemory = randomAccessMemory;
        ComputerСase = computerСase;
        PowerUnit = powerUnit;
        VideoCard = videoCard;
        SsdDrive = ssdDrive;
        HardDrive = hardDrive;
        WiFiAdapter = wiFiAdapter;
    }

    public IMotherboard Motherboard { get; }
    public ICentralProcessingUnit CentralProcessingUnit { get; }
    public IProcessorCoolingSystem ProcessorCoolingSystem { get; }
    public IRandomAccessMemory RandomAccessMemory { get; }
    public IComputerСase ComputerСase { get; }
    public IPowerUnit PowerUnit { get; }
    public IVideoCard? VideoCard { get; }
    public ISsdDrive? SsdDrive { get; }
    public IHardDrive? HardDrive { get; }
    public IWiFiAdapter? WiFiAdapter { get; }

    public IComputer Clone()
    {
        return new Computer(
            Motherboard.Clone(),
            CentralProcessingUnit.Clone(),
            ProcessorCoolingSystem.Clone(),
            RandomAccessMemory.Clone(),
            ComputerСase.Clone(),
            PowerUnit.Clone(),
            VideoCard?.Clone(),
            SsdDrive?.Clone(),
            HardDrive?.Clone(),
            WiFiAdapter?.Clone());
    }
}