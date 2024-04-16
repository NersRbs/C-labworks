using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.PhotonicDeflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

public class DeflectorClass3 : IDeflector
{
    public DeflectorClass3(IPhotonicDeflector photonicDeflector)
    {
        HealthPoints = 200;
        PhotonicDeflector = photonicDeflector;
    }

    public DeflectorClass3()
        : this(new NullPhotonicDeflector()) { }

    public HealthPoints HealthPoints { get; }
    public IPhotonicDeflector PhotonicDeflector { get; }

    public uint TakeDamage(uint damage)
    {
        uint coefficient;
        switch (damage)
        {
            case <= 1:
                coefficient = 5;
                break;
            case <=5:
                coefficient = 4;
                break;
            case <= 10:
                coefficient = 20;
                break;
            default:
                coefficient = 100;
                break;
        }

        uint totalDeflectorDamage = damage * coefficient;
        uint remainingDamage = totalDeflectorDamage - Math.Min(totalDeflectorDamage, (uint)HealthPoints.Health);

        HealthPoints.Damage(totalDeflectorDamage);
        return remainingDamage / coefficient;
    }
}