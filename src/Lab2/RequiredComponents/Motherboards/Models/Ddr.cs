using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;

public struct Ddr : IEquatable<Ddr>
{
    public Ddr(string model)
    {
        Model = model;
    }

    public string Model { get; }

    public static bool operator ==(Ddr left, Ddr right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Ddr left, Ddr right)
    {
        return !(left == right);
    }

    public bool Equals(Ddr other)
    {
        return Model == other.Model;
    }

    public override bool Equals(object? obj)
    {
        return obj is Ddr ddr && Equals(ddr);
    }

    public override int GetHashCode()
    {
        return Model.GetHashCode(StringComparison.CurrentCulture);
    }
}