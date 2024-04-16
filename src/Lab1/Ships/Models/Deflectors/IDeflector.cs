using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.PhotonicDeflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

public interface IDeflector
{
    HealthPoints HealthPoints { get; }

    IPhotonicDeflector PhotonicDeflector { get; }

    uint TakeDamage(uint damage);
}