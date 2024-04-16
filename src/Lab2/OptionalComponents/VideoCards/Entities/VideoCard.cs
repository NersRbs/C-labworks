using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.VideoCards.Entities;

public class VideoCard : IVideoCard
{
    public VideoCard(
        string model,
        Size heightAndWidthVideoCard,
        int countOfVideoMemory,
        Version versionPciE,
        int chipFrequency,
        int powerConsumption)
    {
        Model = model;
        HeightAndWidthVideoCard = heightAndWidthVideoCard;
        CountOfVideoMemory = countOfVideoMemory;
        VersionPciE = versionPciE;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public string Model { get; }

    public Size HeightAndWidthVideoCard { get; }

    public int CountOfVideoMemory { get; }

    public Version VersionPciE { get; }

    public int ChipFrequency { get; }

    public int PowerConsumption { get; }

    public IVideoCard Clone()
    {
        return new VideoCard(
            Model,
            HeightAndWidthVideoCard,
            CountOfVideoMemory,
            VersionPciE,
            ChipFrequency,
            PowerConsumption);
    }
}