using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.VideoCards.Entities;

public class VideoCardBuilder : IVideoCardBuilder
{
    private string? _model;
    private Size? _heightAndWidthVideoCard;
    private int? _countOfVideoMemory;
    private Version? _versionPciE;
    private int? _chipFrequency;
    private int? _powerConsumption;

    public IVideoCardBuilder SetModel(string model)
    {
        _model = model;
        return this;
    }

    public IVideoCardBuilder SetHeightAndWidthVideoCard(Size heightAndWidthVideoCard)
    {
        _heightAndWidthVideoCard = heightAndWidthVideoCard;
        return this;
    }

    public IVideoCardBuilder SetCountOfVideoMemory(int countOfVideoMemory)
    {
        _countOfVideoMemory = countOfVideoMemory;
        return this;
    }

    public IVideoCardBuilder SetVersionPciE(Version versionPciE)
    {
        _versionPciE = versionPciE;
        return this;
    }

    public IVideoCardBuilder SetChipFrequency(int chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public IVideoCardBuilder SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IVideoCard Build()
    {
        if (_model is null ||
            _heightAndWidthVideoCard is null ||
            _countOfVideoMemory is null ||
            _versionPciE is null ||
            _chipFrequency is null ||
            _powerConsumption is null)
        {
            throw new InvalidOperationException("Not all fields are filled");
        }

        return new VideoCard(
            _model,
            _heightAndWidthVideoCard.Value,
            _countOfVideoMemory.Value,
            _versionPciE,
            _chipFrequency.Value,
            _powerConsumption.Value);
    }
}