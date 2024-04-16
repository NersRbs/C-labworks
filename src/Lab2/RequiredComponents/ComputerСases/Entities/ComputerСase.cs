using System;
using System.Collections.Generic;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.ComputerСases.Entities;

public class ComputerСase : IComputerСase
{
    public ComputerСase(
        string model,
        Size maximumLengthAndWidthVideoCard,
        HashSet<FormFactor> supportedFormFactorsOfMotherboards,
        double dimensions)
    {
        if (dimensions <= 0)
        {
            throw new ArgumentException("Dimensions must be positive", nameof(dimensions));
        }

        Model = model;
        MaximumLengthAndWidthVideoCard = maximumLengthAndWidthVideoCard;
        SupportedFormFactorsOfMotherboards = supportedFormFactorsOfMotherboards;
        Dimensions = dimensions;
    }

    public string Model { get; }
    public Size MaximumLengthAndWidthVideoCard { get; }
    public HashSet<FormFactor> SupportedFormFactorsOfMotherboards { get; }
    public double Dimensions { get; }

    public IComputerСase Clone()
    {
        return new ComputerСase(
            Model,
            MaximumLengthAndWidthVideoCard,
            SupportedFormFactorsOfMotherboards,
            Dimensions);
    }
}