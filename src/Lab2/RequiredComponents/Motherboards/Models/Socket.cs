using System;
using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;

public struct Socket : IModel, IEquatable<Socket>
{
    public Socket(string model)
    {
        Model = model;
    }

    public string Model { get; }

    public static bool operator ==(Socket left, Socket right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Socket left, Socket right)
    {
        return !(left == right);
    }

    public bool Equals(Socket other)
    {
        return Model == other.Model;
    }

    public override bool Equals(object? obj)
    {
        return obj is Socket socket && Equals(socket);
    }

    public override int GetHashCode()
    {
        return Model.GetHashCode(StringComparison.CurrentCulture);
    }
}