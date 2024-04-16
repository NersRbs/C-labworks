using System.Collections.Generic;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.ComputerСases.Entities;

public interface IComputerСase : IModel, IPrototype<IComputerСase>
{
    Size MaximumLengthAndWidthVideoCard { get; }
    HashSet<FormFactor> SupportedFormFactorsOfMotherboards { get; }
    double Dimensions { get; }
}