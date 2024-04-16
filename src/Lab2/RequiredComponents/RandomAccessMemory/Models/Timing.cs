using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.RandomAccessMemory.Models;

public struct Timing : IEquatable<Timing>
{
    public Timing(int rasToCas, int rasPrecharge, int tras, int trc)
    {
        RasToCas = rasToCas;
        RasPrecharge = rasPrecharge;
        Tras = tras;
        Trc = trc;
    }

    public int RasToCas { get; }
    public int RasPrecharge { get; }
    public int Tras { get; }
    public int Trc { get; }

    public static bool operator ==(Timing left, Timing right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Timing left, Timing right)
    {
        return !(left == right);
    }

    public readonly bool Equals(Timing other)
    {
        return RasToCas == other.RasToCas && RasPrecharge == other.RasPrecharge && Tras == other.Tras && Trc == other.Trc;
    }

    public readonly override bool Equals(object? obj)
    {
        return obj is Timing timing && Equals(timing);
    }

    public readonly override int GetHashCode()
    {
        return HashCode.Combine(RasToCas, RasPrecharge, Tras, Trc);
    }
}