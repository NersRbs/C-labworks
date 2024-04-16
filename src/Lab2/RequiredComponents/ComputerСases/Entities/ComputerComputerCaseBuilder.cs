using System.Collections.Generic;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.ComputerСases.Entities;

public class ComputerComputerCaseBuilder : IComputerCaseBuilder
{
    private string? _model;
    private Size? _maximumLengthAndWidthVideoCard;
    private HashSet<FormFactor>? _supportedFormFactorsOfMotherboards;
    private double? _dimensions;

    public IComputerCaseBuilder SetModel(string model)
    {
        _model = model;
        return this;
    }

    public IComputerCaseBuilder SetMaximumLengthAndWidthVideoCard(Size maximumLengthAndWidthVideoCard)
    {
        _maximumLengthAndWidthVideoCard = maximumLengthAndWidthVideoCard;
        return this;
    }

    public IComputerCaseBuilder SetSupportedFormFactorsOfMotherboards(HashSet<FormFactor> supportedFormFactorsOfMotherboards)
    {
        _supportedFormFactorsOfMotherboards = supportedFormFactorsOfMotherboards;
        return this;
    }

    public IComputerCaseBuilder SetDimensions(double dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public IComputerСase Build()
    {
        if (_model is null ||
            _maximumLengthAndWidthVideoCard is null ||
            _supportedFormFactorsOfMotherboards is null ||
            _dimensions is null)
        {
            throw new System.InvalidOperationException("Not all fields are filled");
        }

        return new ComputerСase(
            _model,
            _maximumLengthAndWidthVideoCard.Value,
            _supportedFormFactorsOfMotherboards,
            _dimensions.Value);
    }
}