namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.HardDrives.Entities;

public class HardDrive : IHardDrive
{
    public HardDrive(string model, int capacity, int spindleRotationSpeed, int powerConsumption)
    {
        Model = model;
        Capacity = capacity;
        SpindleRotationSpeed = spindleRotationSpeed;
        PowerConsumption = powerConsumption;
    }

    public string Model { get; }

    public int Capacity { get; }

    public int SpindleRotationSpeed { get; }

    public int PowerConsumption { get; }

    public IHardDrive Clone()
    {
        return new HardDrive(Model, Capacity, SpindleRotationSpeed, PowerConsumption);
    }
}