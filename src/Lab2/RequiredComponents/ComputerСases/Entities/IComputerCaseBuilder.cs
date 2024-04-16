using System.Collections.Generic;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.ComputerСases.Entities;

public interface IComputerCaseBuilder
{
    IComputerCaseBuilder SetModel(string model);
    IComputerCaseBuilder SetMaximumLengthAndWidthVideoCard(Size maximumLengthAndWidthVideoCard);
    IComputerCaseBuilder SetSupportedFormFactorsOfMotherboards(HashSet<FormFactor> supportedFormFactorsOfMotherboards);
    IComputerCaseBuilder SetDimensions(double dimensions);
    IComputerСase Build();
}