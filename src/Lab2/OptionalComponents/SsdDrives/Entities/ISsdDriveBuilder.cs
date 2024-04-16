using Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.SsdDrives.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.SsdDrives.Entities;

public interface ISsdDriveBuilder
{
    ISsdDriveBuilder SetModel(string model);
    ISsdDriveBuilder SetConnectionOption(ConnectionOption connectionOption);
    ISsdDriveBuilder SetCapacity(int capacity);
    ISsdDriveBuilder SetMaximumOperatingSpeed(int maximumOperatingSpeed);
    ISsdDriveBuilder SetPowerConsumption(int powerConsumption);
    ISsdDrive Build();
}