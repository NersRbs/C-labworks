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

public interface IConfigurator
{
    Configurator SetMotherboard(IMotherboard motherboard);
    Configurator SetCentralProcessingUnit(ICentralProcessingUnit centralProcessingUnit);
    Configurator SetProcessorCoolingSystem(IProcessorCoolingSystem processorCoolingSystem);
    Configurator SetRandomAccessMemory(IRandomAccessMemory randomAccessMemory);
    Configurator SetCase(IComputerСase computerСase);
    Configurator SetPowerUnit(IPowerUnit powerUnit);
    Configurator SetVideoCard(IVideoCard videoCard);
    Configurator SetSsdDrive(ISsdDrive ssdDrive);
    Configurator SetHardDrive(IHardDrive hardDrive);
    Configurator SetWiFiAdapter(IWiFiAdapter wiFiAdapter);
    Status Build();
}