using System;
using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;

public struct FormFactor : IModel, IEquatable<FormFactor>
{
    public FormFactor(string model)
    {
        Model = model;
    }

    public string Model { get; }

    public static bool operator ==(FormFactor left, FormFactor right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(FormFactor left, FormFactor right)
    {
        return !(left == right);
    }

    public bool Equals(FormFactor other)
    {
        return Model == other.Model;
    }

    public override bool Equals(object? obj)
    {
        return obj is FormFactor formFactor && Equals(formFactor);
    }

    public override int GetHashCode()
    {
        return Model.GetHashCode(StringComparison.CurrentCulture);
    }
}