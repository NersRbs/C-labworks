namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.HardDrives.Entities;

public interface IHardDriveBuilder
{
    IHardDriveBuilder SetModel(string model);
    IHardDriveBuilder SetCapacity(int capacity);
    IHardDriveBuilder SetSpindleRotationSpeed(int spindleRotationSpeed);
    IHardDriveBuilder SetPowerConsumption(int powerConsumption);
    IHardDrive Build();
}