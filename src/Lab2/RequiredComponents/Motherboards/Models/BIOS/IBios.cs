using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.BIOS;

public interface IBios : IModel, IPrototype<IBios>
{
    BiosType Type { get; }
    Version Version { get; }
    HashSet<string> ListOfSupportedProcessors { get; }
}