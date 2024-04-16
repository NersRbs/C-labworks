using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.PhotonicDeflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

public class NullDeflector : IDeflector
{
    public HealthPoints HealthPoints { get; } = 0;
    public IPhotonicDeflector PhotonicDeflector { get; } = new NullPhotonicDeflector();
    public uint TakeDamage(uint damage)
    {
        return damage;
    }
}