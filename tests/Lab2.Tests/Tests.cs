using System;
using System.Collections.Generic;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Configurators.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Configurators.Models;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.HardDrives.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.SsdDrives.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.SsdDrives.Models;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.VideoCards.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.WiFiAdapters.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.CentralProcessingUnits.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.ComputerСases.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.PowerUnits.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.ProcessorCoolingSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    private DetailRepository<IModel> _detailRepository;

    public Tests()
    {
        _detailRepository = new DetailRepository<IModel>();
        IMotherboardBuilder motherboardBuilder = new MotherboardBuilder()
            .SetModel("Motherboard")
            .SetSocket(new Socket("Socket"))
            .SetCountOfLinesSolderedPciE(3)
            .SetCountOfPortsSolderedSata(3)
            .SetChipset(new Chipset("Chipset", 50, new XmpProfile("XmpProfile", new Timing(16, 17, 18, 19), 3, 8)))
            .SetSupportedDdrStandard(new Ddr("Ddr"))
            .SetCountOfTablesUnderRam(2)
            .SetFormFactor(new FormFactor("FormFactor"))
            .SetBios(new Bios("Bios", new BiosType.ROM(), new Version(3, 2, 1), new HashSet<string>()));

        IMotherboardBuilder motherboardBuilderWithOtherSocket = new MotherboardBuilder()
            .SetModel("MotherboardWithOtherSocket")
            .SetSocket(new Socket("OtherSocket"))
            .SetCountOfLinesSolderedPciE(3)
            .SetCountOfPortsSolderedSata(3)
            .SetChipset(new Chipset("Chipset", 50, new XmpProfile("XmpProfile", new Timing(16, 17, 18, 19), 3, 8)))
            .SetSupportedDdrStandard(new Ddr("Ddr"))
            .SetCountOfTablesUnderRam(2)
            .SetFormFactor(new FormFactor("FormFactor"))
            .SetBios(new Bios("Bios", new BiosType.ROM(), new Version(3, 2, 1), new HashSet<string>()));

        ICentralProcessingUnitBuilder centralProcessingUnitBuilder = new CentralProcessingUnitBuilder()
            .SetModel("CentralProcessingUnit")
            .SetCoreFrequency(3.2)
            .SetCountOfCores(2)
            .SetSocket(new Socket("Socket"))
            .SetPresenceBuiltInVideoCore(true)
            .SetSupportedMemoryFrequencies(new HashSet<double>() { 3.2 })
            .SetHeatDissipation(50)
            .SetPowerConsumption(50);

        IProcessorCoolingSystemBuilder coolingSystemBuilder = new ProcessorCoolingSystemBuilder()
            .SetModel("ProcessorCoolingSystem")
            .SetDimensions(3)
            .SetSupportedSockets(new HashSet<Socket>() { new Socket("Socket") })
            .SetMaximumDissipatedHeatMass(50);

        IProcessorCoolingSystemBuilder weakCoolingSystemBuilder = new ProcessorCoolingSystemBuilder()
            .SetModel("WeakProcessorCoolingSystem")
            .SetDimensions(3)
            .SetSupportedSockets(new HashSet<Socket>() { new Socket("Socket") })
            .SetMaximumDissipatedHeatMass(10);

        IRandomAccessMemoryBuilder randomAccessMemoryBuilder = new RandomAccessMemoryBuilder()
            .SetModel("RandomAccessMemory")
            .SetCountOfAvailableMemorySize(2)
            .SetSupportedJedecAndVoltageFrequencyPairs(true)
            .SetAvailableXmpOrDocpProfiles(new HashSet<XmpProfile>() { new XmpProfile("XmpProfile", new Timing(16, 17, 18, 19), 3, 8) })
            .SetFormFactor(new FormFactor("FormFactor"))
            .SetDdrStandardVersion(new Version(3, 2, 1))
            .SetPowerConsumption(50);

        IRandomAccessMemoryBuilder randomAccessMemoryBuilderWithOtherFormFactor = new RandomAccessMemoryBuilder()
            .SetModel("RandomAccessMemoryWithOtherFormFactor")
            .SetCountOfAvailableMemorySize(2)
            .SetSupportedJedecAndVoltageFrequencyPairs(true)
            .SetAvailableXmpOrDocpProfiles(new HashSet<XmpProfile>() { new XmpProfile("XmpProfile", new Timing(16, 17, 18, 19), 3, 8) })
            .SetFormFactor(new FormFactor("OtherFormFactor"))
            .SetDdrStandardVersion(new Version(3, 2, 1))
            .SetPowerConsumption(50);

        IComputerCaseBuilder computerCaseBuilder = new ComputerComputerCaseBuilder()
            .SetModel("Case")
            .SetMaximumLengthAndWidthVideoCard(new Size(3, 2))
            .SetSupportedFormFactorsOfMotherboards(new HashSet<FormFactor>() { new FormFactor("FormFactor") })
            .SetDimensions(20);

        IPowerUnitBuilder powerUnitBuilder = new PowerUnitBuilder()
            .SetModel("PowerUnit")
            .SetPeakLoad(50);

        IPowerUnitBuilder weakPowerUnitBuilder = new PowerUnitBuilder()
            .SetModel("WeakPowerUnit")
            .SetPeakLoad(10);

        IHardDriveBuilder hardDriveBuilder = new HardDriveBuilder()
            .SetModel("HardDrive")
            .SetCapacity(50)
            .SetSpindleRotationSpeed(20)
            .SetPowerConsumption(20);

        IVideoCardBuilder videoCardBuilder = new VideoCardBuilder()
            .SetModel("VideoCard")
            .SetHeightAndWidthVideoCard(new Size(3, 2))
            .SetCountOfVideoMemory(2)
            .SetVersionPciE(new Version(3, 2, 1))
            .SetChipFrequency(3)
            .SetPowerConsumption(20);

        ISsdDriveBuilder ssdDriveBuilder = new SsdDriveBuilder()
            .SetModel("SsdDrive")
            .SetConnectionOption(ConnectionOption.PciE)
            .SetCapacity(50)
            .SetMaximumOperatingSpeed(20)
            .SetPowerConsumption(20);

        IWiFiAdapterBuild wiFiAdapterBuild = new WiFiAdapterBuild()
            .SetModel("WiFiAdapter")
            .SetVersionWiFiStandard(new Version(3, 0, 0))
            .SetThePresenceBluetoothModule(true)
            .SetVersionPciE(new Version(3, 2, 1))
            .SetPowerConsumption(20);

        _detailRepository.Add(motherboardBuilder.Build());
        _detailRepository.Add(motherboardBuilderWithOtherSocket.Build());
        _detailRepository.Add(centralProcessingUnitBuilder.Build());
        _detailRepository.Add(coolingSystemBuilder.Build());
        _detailRepository.Add(weakCoolingSystemBuilder.Build());
        _detailRepository.Add(randomAccessMemoryBuilder.Build());
        _detailRepository.Add(randomAccessMemoryBuilderWithOtherFormFactor.Build());
        _detailRepository.Add(computerCaseBuilder.Build());
        _detailRepository.Add(powerUnitBuilder.Build());
        _detailRepository.Add(weakPowerUnitBuilder.Build());
        _detailRepository.Add(hardDriveBuilder.Build());
        _detailRepository.Add(videoCardBuilder.Build());
        _detailRepository.Add(ssdDriveBuilder.Build());
        _detailRepository.Add(wiFiAdapterBuild.Build());
    }

    [Fact]
    public void Build_ShouldResulSuccess()
    {
        // Arrange
        Configurator configurator = new Configurator()
            .SetMotherboard((Motherboard)_detailRepository.GetByName("Motherboard"))
            .SetCentralProcessingUnit((CentralProcessingUnit)_detailRepository.GetByName("CentralProcessingUnit"))
            .SetProcessorCoolingSystem((ProcessorCoolingSystem)_detailRepository.GetByName("ProcessorCoolingSystem"))
            .SetRandomAccessMemory((RandomAccessMemory)_detailRepository.GetByName("RandomAccessMemory"))
            .SetCase((ComputerСase)_detailRepository.GetByName("Case"))
            .SetPowerUnit((PowerUnit)_detailRepository.GetByName("PowerUnit"))
            .SetHardDrive((HardDrive)_detailRepository.GetByName("HardDrive"));

        // Act
        Status result = configurator.Build();

        // Assert
        Assert.IsType<Status.Success>(result);
    }

    [Fact]
    public void Build_ShouldResultPowerUnitWarning()
    {
        // Arrange
        Configurator configurator = new Configurator()
            .SetMotherboard((Motherboard)_detailRepository.GetByName("Motherboard"))
            .SetCentralProcessingUnit((CentralProcessingUnit)_detailRepository.GetByName("CentralProcessingUnit"))
            .SetProcessorCoolingSystem((ProcessorCoolingSystem)_detailRepository.GetByName("ProcessorCoolingSystem"))
            .SetRandomAccessMemory((RandomAccessMemory)_detailRepository.GetByName("RandomAccessMemory"))
            .SetCase((ComputerСase)_detailRepository.GetByName("Case"))
            .SetPowerUnit((PowerUnit)_detailRepository.GetByName("WeakPowerUnit"))
            .SetHardDrive((HardDrive)_detailRepository.GetByName("HardDrive"));

        // Act
        Status result = configurator.Build();

        // Assert
        Assert.IsType<Status.Warning>(result);
        var warning = (Status.Warning)result;
        Assert.Equal("The permissible power consumption has been exceeded", warning.Message);
    }

    [Fact]
    public void Build_ShouldResultProcessorCoolingSystemWarning()
    {
        // Arrange
        Configurator configurator = new Configurator()
            .SetMotherboard((Motherboard)_detailRepository.GetByName("Motherboard"))
            .SetCentralProcessingUnit((CentralProcessingUnit)_detailRepository.GetByName("CentralProcessingUnit"))
            .SetProcessorCoolingSystem((ProcessorCoolingSystem)_detailRepository.GetByName("WeakProcessorCoolingSystem"))
            .SetRandomAccessMemory((RandomAccessMemory)_detailRepository.GetByName("RandomAccessMemory"))
            .SetCase((ComputerСase)_detailRepository.GetByName("Case"))
            .SetPowerUnit((PowerUnit)_detailRepository.GetByName("PowerUnit"))
            .SetHardDrive((HardDrive)_detailRepository.GetByName("HardDrive"));

        // Act
        Status result = configurator.Build();

        // Assert
        Assert.IsType<Status.Warning>(result);
        var warning = (Status.Warning)result;
        Assert.Equal("Disclaimer of warranty obligations", warning.Message);
    }

    [Fact]
    public void Build_ShouldResultImpossibleToBuildWithSocketMassage()
    {
        // Arrange
        Configurator configurator = new Configurator()
            .SetMotherboard((Motherboard)_detailRepository.GetByName("MotherboardWithOtherSocket"))
            .SetCentralProcessingUnit((CentralProcessingUnit)_detailRepository.GetByName("CentralProcessingUnit"))
            .SetProcessorCoolingSystem((ProcessorCoolingSystem)_detailRepository.GetByName("ProcessorCoolingSystem"))
            .SetRandomAccessMemory((RandomAccessMemory)_detailRepository.GetByName("RandomAccessMemory"))
            .SetCase((ComputerСase)_detailRepository.GetByName("Case"))
            .SetPowerUnit((PowerUnit)_detailRepository.GetByName("PowerUnit"))
            .SetHardDrive((HardDrive)_detailRepository.GetByName("HardDrive"));

        // Act
        Status result = configurator.Build();

        // Assert
        Assert.IsType<Status.ImpossibleToBuild>(result);
        var impossibleToBuild = (Status.ImpossibleToBuild)result;
        Assert.Equal("The processor socket does not match the motherboard socket", impossibleToBuild.Message);
    }

    [Fact]
    public void Build_ShouldResultImpossibleToBuildWithDeviceMassage()
    {
        // Arrange
        Configurator configurator = new Configurator()
            .SetMotherboard((Motherboard)_detailRepository.GetByName("Motherboard"))
            .SetCentralProcessingUnit((CentralProcessingUnit)_detailRepository.GetByName("CentralProcessingUnit"))
            .SetProcessorCoolingSystem((ProcessorCoolingSystem)_detailRepository.GetByName("ProcessorCoolingSystem"))
            .SetRandomAccessMemory((RandomAccessMemory)_detailRepository.GetByName("RandomAccessMemory"))
            .SetCase((ComputerСase)_detailRepository.GetByName("Case"))
            .SetPowerUnit((PowerUnit)_detailRepository.GetByName("PowerUnit"));

        // Act
        Status result = configurator.Build();

        // Assert
        Assert.IsType<Status.ImpossibleToBuild>(result);
        var impossibleToBuild = (Status.ImpossibleToBuild)result;
        Assert.Equal("The computer does not have a storage device", impossibleToBuild.Message);
    }

    [Fact]
    public void Build_ShouldResultImpossibleToBuildWithFormFactorMassage()
    {
        // Arrange
        Configurator configurator = new Configurator()
            .SetMotherboard((Motherboard)_detailRepository.GetByName("Motherboard"))
            .SetCentralProcessingUnit((CentralProcessingUnit)_detailRepository.GetByName("CentralProcessingUnit"))
            .SetProcessorCoolingSystem((ProcessorCoolingSystem)_detailRepository.GetByName("ProcessorCoolingSystem"))
            .SetRandomAccessMemory((RandomAccessMemory)_detailRepository.GetByName("RandomAccessMemoryWithOtherFormFactor"))
            .SetCase((ComputerСase)_detailRepository.GetByName("Case"))
            .SetPowerUnit((PowerUnit)_detailRepository.GetByName("PowerUnit"))
            .SetHardDrive((HardDrive)_detailRepository.GetByName("HardDrive"))
            .SetVideoCard((VideoCard)_detailRepository.GetByName("VideoCard"))
            .SetSsdDrive((SsdDrive)_detailRepository.GetByName("SsdDrive"))
            .SetWiFiAdapter((WiFiAdapter)_detailRepository.GetByName("WiFiAdapter"));

        // Act
        Status result = configurator.Build();

        // Assert
        Assert.IsType<Status.ImpossibleToBuild>(result);
        var impossibleToBuild = (Status.ImpossibleToBuild)result;
        Assert.Equal("The form factor of the RAM does not match the form factor of the motherboard", impossibleToBuild.Message);
    }
}