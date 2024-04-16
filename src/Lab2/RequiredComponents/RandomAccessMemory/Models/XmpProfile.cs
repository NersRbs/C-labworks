using System;
using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Models;

public struct XmpProfile : IModel, IEquatable<XmpProfile>
{
    public XmpProfile(string model, Timing timing, float voltage, int frequency)
    {
        Model = model;
        Timing = timing;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Model { get; }

    public Timing Timing { get; }

    public float Voltage { get; }
    public int Frequency { get; }

    public static bool operator ==(XmpProfile left, XmpProfile right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(XmpProfile left, XmpProfile right)
    {
        return !(left == right);
    }

    public readonly bool Equals(XmpProfile other)
    {
        return Model == other.Model;
    }

    public readonly override bool Equals(object? obj)
    {
        return obj is XmpProfile formFactor && Equals(formFactor);
    }

    public readonly override int GetHashCode()
    {
        return Model.GetHashCode(StringComparison.CurrentCulture);
    }
}