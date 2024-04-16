using Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.SsdDrives.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.SsdDrives.Entities;

public class SsdDrive : ISsdDrive
{
    public SsdDrive(
        string model,
        ConnectionOption connectionOption,
        int capacity,
        int maximumOperatingSpeed,
        int powerConsumption)
    {
        Model = model;
        ConnectionOption = connectionOption;
        Capacity = capacity;
        MaximumOperatingSpeed = maximumOperatingSpeed;
        PowerConsumption = powerConsumption;
    }

    public string Model { get; }

    public ConnectionOption ConnectionOption { get; }

    public int Capacity { get; }

    public int MaximumOperatingSpeed { get; }

    public int PowerConsumption { get; }

    public ISsdDrive Clone()
    {
        return new SsdDrive(
            Model,
            ConnectionOption,
            Capacity,
            MaximumOperatingSpeed,
            PowerConsumption);
    }
}