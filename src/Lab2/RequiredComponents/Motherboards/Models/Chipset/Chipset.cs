using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.Chipset;

public class Chipset : IChipset
{
    public Chipset(string model, uint frequency, XmpProfile xmpSupport)
    {
        Model = model;
        Frequency = frequency;
        XmpSupport = xmpSupport;
    }

    public string Model { get; }

    public uint Frequency { get; }

    public XmpProfile XmpSupport { get; }

    public IChipset Clone()
    {
        return new Chipset(Model, Frequency, XmpSupport);
    }
}