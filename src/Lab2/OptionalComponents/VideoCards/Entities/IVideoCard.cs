using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.VideoCards.Entities;

public interface IVideoCard : IModel, IPrototype<IVideoCard>
{
    Size HeightAndWidthVideoCard { get; }
    int CountOfVideoMemory { get; }
    Version VersionPciE { get; }
    int ChipFrequency { get; }
    int PowerConsumption { get; }
}