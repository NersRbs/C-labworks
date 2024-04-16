using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.VideoCards.Entities;

public interface IVideoCardBuilder
{
    IVideoCardBuilder SetModel(string model);

    IVideoCardBuilder SetHeightAndWidthVideoCard(Size heightAndWidthVideoCard);
    IVideoCardBuilder SetCountOfVideoMemory(int countOfVideoMemory);
    IVideoCardBuilder SetVersionPciE(Version versionPciE);
    IVideoCardBuilder SetChipFrequency(int chipFrequency);
    IVideoCardBuilder SetPowerConsumption(int powerConsumption);
    IVideoCard Build();
}