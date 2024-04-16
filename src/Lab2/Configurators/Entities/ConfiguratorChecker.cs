using Itmo.ObjectOrientedProgramming.Lab2.Computers.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Configurators.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Configurators.Entities;

public class ConfiguratorChecker : IConfiguratorChecker
{
    public Status Check(IComputer computer)
    {
        if (computer.Motherboard.Socket != computer.CentralProcessingUnit.Socket)
        {
            return new Status.ImpossibleToBuild("The processor socket does not match the motherboard socket");
        }

        if (!computer.CentralProcessingUnit.PresenceBuiltInVideoCore && computer.VideoCard is null)
        {
            return new Status.ImpossibleToBuild("The processor does not have a built-in video core and the video card is not installed");
        }

        if (computer.RandomAccessMemory.FormFactor != computer.Motherboard.FormFactor)
        {
            return new Status.ImpossibleToBuild("The form factor of the RAM does not match the form factor of the motherboard");
        }

        if (!computer.RandomAccessMemory.AvailableXmpOrDocpProfiles.Contains(computer.Motherboard.Chipset.XmpSupport))
        {
            return new Status.ImpossibleToBuild("The RAM does not support the XMP profile of the motherboard");
        }

        if (computer.SsdDrive is null && computer.HardDrive is null)
        {
            return new Status.ImpossibleToBuild("The computer does not have a storage device");
        }

        if (computer.ProcessorCoolingSystem.Dimensions > computer.ComputerСase.Dimensions)
        {
            return new Status.ImpossibleToBuild("The dimensions of the processor cooling system exceed the dimensions of the computer case");
        }

        if (computer.VideoCard is not null &&
            (computer.VideoCard.HeightAndWidthVideoCard.Width > computer.ComputerСase.MaximumLengthAndWidthVideoCard.Width ||
             computer.VideoCard.HeightAndWidthVideoCard.Height > computer.ComputerСase.MaximumLengthAndWidthVideoCard.Height))
        {
            return new Status.ImpossibleToBuild("The dimensions of the video card exceed the dimensions of the computer case");
        }

        if (computer.CentralProcessingUnit.HeatDissipation > computer.ProcessorCoolingSystem.MaximumDissipatedHeatMass)
        {
            return new Status.Warning("Disclaimer of warranty obligations", computer);
        }

        if (computer.PowerUnit.PeakLoad < computer.CentralProcessingUnit.PowerConsumption ||
            computer.PowerUnit.PeakLoad < computer.RandomAccessMemory.PowerConsumption ||
            computer.PowerUnit.PeakLoad < computer.VideoCard?.PowerConsumption ||
            computer.PowerUnit.PeakLoad < computer.SsdDrive?.PowerConsumption ||
            computer.PowerUnit.PeakLoad < computer.HardDrive?.PowerConsumption ||
            computer.PowerUnit.PeakLoad < computer.WiFiAdapter?.PowerConsumption)
        {
            return new Status.Warning("The permissible power consumption has been exceeded", computer);
        }

        return new Status.Success(computer);
    }
}