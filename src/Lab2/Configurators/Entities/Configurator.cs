using Itmo.ObjectOrientedProgramming.Lab2.Computers.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Configurators.Models;
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

namespace Itmo.ObjectOrientedProgramming.Lab2.Configurators.Entities;

public class Configurator : IConfigurator
{
    private readonly IConfiguratorChecker _configuratorChecker = new ConfiguratorChecker();
    private IMotherboard? _motherboard;
    private ICentralProcessingUnit? _centralProcessingUnit;
    private IProcessorCoolingSystem? _processorCoolingSystem;
    private IRandomAccessMemory? _randomAccessMemory;
    private IComputerСase? _corpus;
    private IPowerUnit? _powerUnit;
    private IVideoCard? _videoCard;
    private ISsdDrive? _ssdDrive;
    private IHardDrive? _hardDrive;
    private IWiFiAdapter? _wiFiAdapter;

    public Configurator() { }
    public Configurator(IComputer computer)
    {
        _motherboard = computer.Motherboard.Clone();
        _centralProcessingUnit = computer.CentralProcessingUnit.Clone();
        _processorCoolingSystem = computer.ProcessorCoolingSystem.Clone();
        _randomAccessMemory = computer.RandomAccessMemory.Clone();
        _corpus = computer.ComputerСase.Clone();
        _powerUnit = computer.PowerUnit.Clone();
        _videoCard = computer.VideoCard?.Clone();
        _ssdDrive = computer.SsdDrive?.Clone();
        _hardDrive = computer.HardDrive?.Clone();
        _wiFiAdapter = computer.WiFiAdapter?.Clone();
    }

    public Configurator SetMotherboard(IMotherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public Configurator SetCentralProcessingUnit(ICentralProcessingUnit centralProcessingUnit)
    {
        _centralProcessingUnit = centralProcessingUnit;
        return this;
    }

    public Configurator SetProcessorCoolingSystem(IProcessorCoolingSystem processorCoolingSystem)
    {
        _processorCoolingSystem = processorCoolingSystem;
        return this;
    }

    public Configurator SetRandomAccessMemory(IRandomAccessMemory randomAccessMemory)
    {
        _randomAccessMemory = randomAccessMemory;
        return this;
    }

    public Configurator SetCase(IComputerСase computerСase)
    {
        _corpus = computerСase;
        return this;
    }

    public Configurator SetPowerUnit(IPowerUnit powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public Configurator SetVideoCard(IVideoCard videoCard)
    {
        _videoCard = videoCard;
        return this;
    }

    public Configurator SetSsdDrive(ISsdDrive ssdDrive)
    {
        _ssdDrive = ssdDrive;
        return this;
    }

    public Configurator SetHardDrive(IHardDrive hardDrive)
    {
        _hardDrive = hardDrive;
        return this;
    }

    public Configurator SetWiFiAdapter(IWiFiAdapter wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }

    public Status Build()
    {
        if (_motherboard is null)
        {
            return new Status.ImpossibleToBuild("Motherboard is not set");
        }

        if (_centralProcessingUnit is null)
        {
            return new Status.ImpossibleToBuild("Central processing unit is not set");
        }

        if (_processorCoolingSystem is null)
        {
            return new Status.ImpossibleToBuild("Processor cooling system is not set");
        }

        if (_randomAccessMemory is null)
        {
            return new Status.ImpossibleToBuild("Random access memory is not set");
        }

        if (_corpus is null)
        {
            return new Status.ImpossibleToBuild("Computer case is not set");
        }

        if (_powerUnit is null)
        {
            return new Status.ImpossibleToBuild("Power unit is not set");
        }

        var computer = new Computer(
            _motherboard,
            _centralProcessingUnit,
            _processorCoolingSystem,
            _randomAccessMemory,
            _corpus,
            _powerUnit,
            _videoCard,
            _ssdDrive,
            _hardDrive,
            _wiFiAdapter);

        return _configuratorChecker.Check(computer.Clone());
    }
}