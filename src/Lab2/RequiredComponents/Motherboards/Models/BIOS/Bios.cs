using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.BIOS;

public class Bios : IBios
{
    public Bios(string model, BiosType type, Version version, HashSet<string> listOfSupportedProcessors)
    {
        Model = model;
        Type = type;
        Version = version;
        ListOfSupportedProcessors = listOfSupportedProcessors;
    }

    public string Model { get; }

    public BiosType Type { get; }

    public Version Version { get; }

    public HashSet<string> ListOfSupportedProcessors { get; }

    public IBios Clone()
    {
        return new Bios(
            Model,
            Type,
            Version,
            ListOfSupportedProcessors);
    }
}